using App.Entities;
using App.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<int> Login(LoginViewModel request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    return -1;
                }

                var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.IsRemember, false);

                if (!result.Succeeded)
                {
                    return -2;
                }

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> Register(RegisterViewModel request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user != null)
                {
                    return -1;
                }

                user = new AppUser()
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FullName = request.FullName,
                    Age = request.Age
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return 1;
                }

                return -2;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
