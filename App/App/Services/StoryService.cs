using App.Data;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using App.Entities;
using Microsoft.AspNetCore.Http;
using App.Utilities;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class StoryService : IStoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileStorageService _fileStorageService;

        public StoryService(ApplicationDbContext db,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IFileStorageService fileStorageService)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _fileStorageService = fileStorageService;
        }

        public async Task<bool> Create(StoryCreateViewModel request)
        {
            var User = _httpContextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(User);

            try
            {
                var story = new Story()
                {
                    AppUser = user,
                    Avatar = await _fileStorageService.SaveFileAsync(request.StoryAvatar, Constains.PathCelebrate),
                    CreatedDate = DateTime.Now,
                    Description = request.Description,
                    Name = request.StoryName
                };

                var storyIntro = new StoryIntro()
                {
                    Audio = await _fileStorageService.SaveFileAsync(request.IntroAudio, Constains.PathAudio),
                    Background = await _fileStorageService.SaveFileAsync(request.IntroBackground, Constains.PathBackground),
                    Question = request.IntroQuesttion,
                    Story = story
                };

                for (int i = 0; i < request.StoryIntroDescriptionItems.Count; i++)
                {
                    await _db.StoryIntroItems.AddAsync(new StoryIntroItem()
                    {
                        Description = request.StoryIntroDescriptionItems[i],
                        StoryIntro = storyIntro
                    });

                    await _db.SaveChangesAsync();
                }



                var storyPoem = new StoryPoem()
                {
                    Audio = await _fileStorageService.SaveFileAsync(request.PoemAudio, Constains.PathAudio),
                    Background = await _fileStorageService.SaveFileAsync(request.PoemBackground, Constains.PathBackground),
                    Story = story,
                    Title = request.PoemTitle,
                    Author =  request.PoemAuthor
                };

                for (int i = 0; i < request.StoryPoemDescriptionItems.Count; i++)
                {
                    await _db.StoryPoemItems.AddAsync(new StoryPoemItem()
                    {
                        Description = request.StoryPoemDescriptionItems[i],
                        StoryPoem = storyPoem
                    });
                    await _db.SaveChangesAsync();
                }

                var storyCelebrate = new StoryCelebrate()
                {
                    Audio = await _fileStorageService.SaveFileAsync(request.CelebrateAudio, Constains.PathAudio),
                    Background = await _fileStorageService.SaveFileAsync(request.CelebrateBackground, Constains.PathBackground),
                    Story = story,
                    Title = request.CelebrateTitle
                };

                var length = request.StoryCelebrateDescriptionItems.Count;
                for (int i = 0; i < length; i++)
                {
                    await _db.StoryCelebrateItems.AddAsync(new StoryCelebrateItem()
                    {
                        Description = request.StoryCelebrateDescriptionItems[i],
                        Image = await _fileStorageService.SaveFileAsync(request.StoryCelebrateImageItems[i], Constains.PathImage),
                        StoryCelebrate = storyCelebrate
                    });
                    await _db.SaveChangesAsync();
                }

                await _db.AddRangeAsync(story, storyIntro, storyPoem, storyCelebrate);
                var result = await _db.SaveChangesAsync();

                return result > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(StoryUpdateRequest request)
        {
            var User = _httpContextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(User);

            try
            {
                var removeFiles = new List<string>();

                // Globals
                var story = await _db.Stories.FirstOrDefaultAsync(s => s.Id == request.Id);

                if (story == null || story.AppUserId != user.Id)
                    return false;

                story.Description = request.Description;
                story.Name = request.StoryName;

                if (request.StoryAvatar != null && request.StoryAvatar.Length > 0)
                {
                    removeFiles.Add(story.Avatar);

                    story.Avatar = await _fileStorageService.SaveFileAsync(request.StoryAvatar, Constains.PathBackground);
                }
                // End Globals

                // StoryIntro
                var storyIntro = await _db.StoryIntros
                        .Include(s => s.StoryIntroItems)
                        .FirstOrDefaultAsync(s => s.StoryId == request.Id);

                storyIntro.Question = request.IntroQuesttion;

                if (request.IntroBackground != null && request.IntroBackground.Length > 0)
                {
                    removeFiles.Add(storyIntro.Background);

                    storyIntro.Background = await _fileStorageService.SaveFileAsync(request.IntroBackground, Constains.PathBackground);
                }
                if (request.IntroAudio != null && request.IntroAudio.Length > 0)
                {
                    removeFiles.Add(storyIntro.Audio);

                    storyIntro.Audio = await _fileStorageService.SaveFileAsync(request.IntroAudio, Constains.PathAudio);
                }

                _db.RemoveRange(storyIntro.StoryIntroItems);
                for (int i = 0; i < request.StoryIntroDescriptionItems.Count; i++)
                {
                    await _db.StoryIntroItems.AddAsync(new StoryIntroItem()
                    {
                        Description = request.StoryIntroDescriptionItems[i],
                        StoryIntroId = storyIntro.Id
                    });
                    await _db.SaveChangesAsync();
                }

                // End StoryIntro

                // Poem
                var storyPoem = await _db.StoryPoems
                        .Include(s => s.StoryPoemItems)
                        .FirstOrDefaultAsync(s => s.StoryId == request.Id);

                storyPoem.Title = request.PoemTitle;
                storyPoem.Author = request.PoemAuthor;

                if (request.PoemBackground != null && request.PoemBackground.Length > 0)
                {
                    removeFiles.Add(storyPoem.Background);

                    storyPoem.Background = await _fileStorageService.SaveFileAsync(request.PoemBackground, Constains.PathBackground);
                }
                if (request.PoemAudio != null && request.PoemAudio.Length > 0)
                {
                    removeFiles.Add(storyPoem.Audio);

                    storyPoem.Audio = await _fileStorageService.SaveFileAsync(request.PoemAudio, Constains.PathAudio);
                }

                for(int  i=0;i< storyPoem.StoryPoemItems.Count;i++)
                {
                    storyPoem.StoryPoemItems[i].Description = request.StoryPoemDescriptionItems[i];
                }

                // End Poem

                // Story Celebrate
                var storyCelebrate = await _db.StoryCelebrates
                        .Include(s => s.StoryCelebrateItems)
                        .FirstOrDefaultAsync(s => s.StoryId == request.Id);

                storyCelebrate.Title = request.CelebrateTitle;

                if (request.CelebrateBackground != null && request.CelebrateBackground.Length > 0)
                {
                    removeFiles.Add(storyCelebrate.Background);

                    storyCelebrate.Background = await _fileStorageService.SaveFileAsync(request.CelebrateBackground, Constains.PathBackground);
                }
                if (request.CelebrateAudio != null && request.CelebrateAudio.Length > 0)
                {
                    removeFiles.Add(storyCelebrate.Audio);

                    storyCelebrate.Audio = await _fileStorageService.SaveFileAsync(request.CelebrateAudio, Constains.PathAudio);
                }

                var celebrateItems = storyCelebrate.StoryCelebrateItems;    // 1 2 3 4  ,obj
                var celebrateItemsRequest = request.CelebrateUpdateRequests;       // 2 3 4 0  , int


                for(int i =0;i< celebrateItems.Count;i++)
                {
                    var item = celebrateItems[i];

                    if (!celebrateItemsRequest.Any(c=>c.Id == item.Id))
                    {
                        // Xóa Items: 1
                        removeFiles.Add(item.Image);
                        _db.Remove(item);
                    }
                    else
                    {
                        // Cập nhật Items: 2 3 4
                        item.Description = request.CelebrateUpdateRequests[i].Description;

                        if(request.CelebrateUpdateRequests[i].Image !=null  && request.CelebrateUpdateRequests[i].Image.Length > 0)
                        {
                            removeFiles.Add(item.Image);

                            item.Image = await _fileStorageService.SaveFileAsync(request.CelebrateUpdateRequests[i].Image, Constains.PathImage);
                        }
                    }
                }

                for (int i = 0; i < celebrateItemsRequest.Count; i++)
                {
                    var item = celebrateItemsRequest[i];
                    if (!item.Id.HasValue || item.Id.Value<=0)
                    {
                        // Thêm mới
                        await _db.StoryCelebrateItems.AddAsync(new StoryCelebrateItem()
                        {
                            Description = request.CelebrateUpdateRequests[i].Description,
                            Image = await _fileStorageService.SaveFileAsync(request.CelebrateUpdateRequests[i].Image, Constains.PathImage),
                            StoryCelebrateId = storyCelebrate.Id
                        });

                        await _db.SaveChangesAsync();
                    }
                }

                // End Story Celebrate

                foreach (var item in removeFiles)
                {
                    // delete
                    await _fileStorageService.DeleteFileAsync(item);
                }

                var result = await _db.SaveChangesAsync();

                return result > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<StoryHomeViewModel>> GetAllShortStory()
        {
            var User = _httpContextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(User);

            try
            {
                return await _db.Stories
                    .Where(s => s.AppUserId == user.Id && !s.IsDelete)
                    .Select(item => new StoryHomeViewModel()
                    {
                        Avatar = item.Avatar,
                        CreatedDate = item.CreatedDate,
                        Description = item.Description,
                        Id = item.Id,
                        Name = item.Name
                    }).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<StoryUpdateRequest> GetByIdUpdate(Guid storyId)
        {
            var story = await _db.Stories
                .Include(s => s.StoryIntro)
                    .ThenInclude(s => s.StoryIntroItems)
                .Include(s => s.StoryPoem)
                    .ThenInclude(s => s.StoryPoemItems)
                .Include(s => s.StoryCelebrate)
                    .ThenInclude(s => s.StoryCelebrateItems)
                .FirstOrDefaultAsync(s => s.Id == storyId);

            if (story == null)
            {
                return null;
            }

            var ls = new List<IFormFile>();

            return new StoryUpdateRequest()
            {
                Id = story.Id,
                StoryName = story.Name,
                StoryAvatar = null,
                StoryAvatarName = story.Avatar,
                Description = story.Description,
                IntroAudio = null,
                IntroAudioName = story.StoryIntro.Audio,
                IntroBackground = null,
                IntroBackgroundName = story.StoryIntro.Background,
                IntroQuesttion = story.StoryIntro.Question,
                StoryIntroDescriptionItems = story.StoryIntro.StoryIntroItems.Select(s => s.Description).ToList(),
                PoemTitle = story.StoryPoem.Title,
                PoemAuthor =  story.StoryPoem.Author,
                PoemAudio = null,
                PoemAudioName = story.StoryPoem.Audio,
                PoemBackground = null,
                PoemBackgroundName = story.StoryPoem.Background,
                StoryPoemDescriptionItems = story.StoryPoem.StoryPoemItems.Select(s => s.Description).ToList(),
                CelebrateAudio = null,
                CelebrateAudioName = story.StoryCelebrate.Audio,
                CelebrateBackground = null,
                CelebrateBackgroundName = story.StoryCelebrate.Background,
                CelebrateTitle = story.StoryCelebrate.Title,
                CelebrateUpdateRequests = story.StoryCelebrate.StoryCelebrateItems.Select(s => new CelebrateUpdateRequest()
                {
                    Description = s.Description,
                    Id = s.Id,
                    Image = null
                }).ToList()
            };
        }

        public async Task<bool> DeleteStory(Guid storyId)
        {
            try
            {
                var story = await _db.Stories.FirstOrDefaultAsync(s => s.Id == storyId);

                if (story == null)
                {
                    return false;
                }

                story.IsDelete = true;
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Story> GetById(Guid storyId)
        {
            var data = await _db.Stories
                .Include(s => s.StoryIntro)
                    .ThenInclude(s => s.StoryIntroItems)
                .Include(s => s.StoryPoem)
                    .ThenInclude(s => s.StoryPoemItems)
                .Include(s => s.StoryCelebrate)
                    .ThenInclude(s => s.StoryCelebrateItems)
                .FirstOrDefaultAsync(s => s.Id == storyId);

            data.StoryIntro.StoryIntroItems.OrderBy(s=>s.Id);
            data.StoryPoem.StoryPoemItems.OrderBy(s=>s.Id);
            data.StoryCelebrate.StoryCelebrateItems.OrderBy(s=>s.Id);

            return data;
        }
    }
}
