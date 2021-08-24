using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class StoryUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên Story"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string StoryName { get; set; }

        [Display(Name = "Avatar")]
        public IFormFile StoryAvatar { get; set; }

        public string  StoryAvatarName { get; set; }

        [Display(Name = "Mô tả"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string Description { get; set; }

        //  Intro
        [Display(Name = "Hình nền")]
        public IFormFile IntroBackground { get; set; }

        public string IntroBackgroundName { get; set; }

        [Display(Name = "Âm nhạc")]
        public IFormFile IntroAudio { get; set; }

        public string IntroAudioName { get; set; }

        [Display(Name = "Câu hỏi"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string IntroQuesttion { get; set; }

        public List<string> StoryIntroDescriptionItems { get; set; }

        //  Poem
        [Display(Name = "Tiêu để"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string PoemTitle { get; set; }

        [Display(Name = "Tác giả"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string PoemAuthor { get; set; }

        [Display(Name = "Hình nền")]
        public IFormFile PoemBackground { get; set; }

        public string PoemBackgroundName { get; set; }

        [Display(Name = "Âm nhạc")]
        public IFormFile PoemAudio { get; set; }

        public string PoemAudioName { get; set; }

        public List<string> StoryPoemDescriptionItems { get; set; }

        // Celebrate
        [Display(Name = "Tiêu đề"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string CelebrateTitle { get; set; }

        [Display(Name = "Hình nền")]
        public IFormFile CelebrateBackground { get; set; }

        public string CelebrateBackgroundName { get; set; }

        [Display(Name = "Âm nhạc")]
        public IFormFile CelebrateAudio { get; set; }

        public string CelebrateAudioName { get; set; }

        public List<CelebrateUpdateRequest> CelebrateUpdateRequests { get; set; }
    }

    public class CelebrateUpdateRequest
    {
        public int? Id { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
    }
}
