using App.Entities;
using App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IStoryService
    {
        Task<bool> Create(StoryCreateViewModel request);
        Task<bool> DeleteStory(Guid storyId);
        Task<List<StoryHomeViewModel>> GetAllShortStory();
        Task<Story> GetById(Guid storyId);
        Task<StoryUpdateRequest> GetByIdUpdate(Guid storyId);
        Task<bool> Update(StoryUpdateRequest request);
    }
}