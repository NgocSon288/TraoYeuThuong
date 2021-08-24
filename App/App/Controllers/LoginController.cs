using App.Entities;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            await _loginService.Logout();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _loginService.Login(model);
            var isOk = result > 0;

            switch (result)
            {
                case -1:
                    ModelState.AddModelError("", "Tài khoản không hợp lệ!");
                    break;
                case -2:
                    ModelState.AddModelError("", "Mật khẩu không hợp lệ!");
                    break;
                case 0:
                    ModelState.AddModelError("", "Lỗi máy chủ!");
                    break;
            }

            if (isOk)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _loginService.Register(model);
            var isOk = result > 0;

            switch (result)
            {
                case -1:
                    ModelState.AddModelError("", "Email đã được sử dụng!");
                    break;
                case -2:
                    ModelState.AddModelError("", "Tạo tài khoản không thành công!");
                    break;
                case -0:
                    ModelState.AddModelError("", "Lỗi máy chủ!");
                    break;
            }

            if (isOk)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
