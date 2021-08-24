using App.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class StoryCreateViewModel
    {
        [Display(Name = "Tên Story"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string StoryName { get; set; }

        [Display(Name = "Avatar"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public IFormFile StoryAvatar { get; set; }

        [Display(Name = "Mô tả"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string Description { get; set; }

        //  Intro
        [Display(Name = "Hình nền"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public IFormFile IntroBackground { get; set; }

        [Display(Name = "Âm nhạc"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public IFormFile IntroAudio { get; set; }

        [Display(Name = "Câu hỏi"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string IntroQuesttion { get; set; }

        public List<string> StoryIntroDescriptionItems { get; set; }

        //  Poem
        [Display(Name = "Tiêu để"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string PoemTitle { get; set; }

        [Display(Name = "Tác giả"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string PoemAuthor { get; set; }

        [Display(Name = "Hình nền"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public IFormFile PoemBackground { get; set; }

        [Display(Name = "Âm nhạc"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public IFormFile PoemAudio { get; set; }

        public List<string> StoryPoemDescriptionItems { get; set; }

        // Celebrate
        [Display(Name = "Tiêu đề"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public string CelebrateTitle { get; set; }

        [Display(Name = "Hình nền"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public IFormFile CelebrateBackground { get; set; }

        [Display(Name = "Âm nhạc"), Required(ErrorMessage = "{0} không được  bỏ trống")]
        public IFormFile CelebrateAudio { get; set; }

        public List<IFormFile> StoryCelebrateImageItems { get; set; }

        public List<string> StoryCelebrateDescriptionItems { get; set; }
    }
}
