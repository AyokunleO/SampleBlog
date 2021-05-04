using Microsoft.AspNetCore.Mvc;
using SampleBlog.Areas.Admin.ViewModels;
using SampleBlog.DAL.Models;
using SampleBlog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IApplicationUserRepository userRepository;

        public UsersController( IApplicationUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var vm = new UsersIndexViewModel
            {
                Users = await userRepository.GetAll()
            };
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new AddUserViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add( AddUserViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = new ApplicationUser
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                Password = vm.Password,
                ProfilePhotoUrl = vm.UserImageUrl
            };
            await userRepository.Add(user);

            TempData["StatusMessage"] = "New User account created successfully";

            return RedirectToAction(nameof(Add));
            //return View(nameof(Add));
        }
    }
}
