using App.Models;
using App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        public async Task<IActionResult> Intro(Guid id)
        {
            var story = await _storyService.GetById(id);

            if(story == null)
            {
                return NotFound("Id không hợp lệ");
            }

            return View(story);
        }
        public async Task<IActionResult> Poem(Guid id)
        {
            var story = await _storyService.GetById(id);

            if (story == null)
            {
                return NotFound("Id không hợp lệ");
            }

            return View(story);
        }
        public async Task<IActionResult> Celebrate(Guid id)
        {
            var story = await _storyService.GetById(id);

            if (story == null)
            {
                return NotFound("Id không hợp lệ");
            }

            return View(story);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result  = await _storyService.Create(model);
            //if (!result)
            //{
            //    return View(model);
            //}

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _storyService.GetByIdUpdate(id);

            if(result == null)
            {
                return Forbid();
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StoryUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _storyService.Update(model);

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _storyService.DeleteStory(id);
            return Json(new {
                isSuccess = result
            });
        }
    }
}
