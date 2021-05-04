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
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var vm = new CategoryIndexViewModel
            {
                Categories = await categoryRepository.GetAll()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddCategoryViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(AddCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var category = new Category
            {
                CategoryName = vm.Name,
                Description = vm.Description
            };
            bool result = await categoryRepository.Add(category);
            if (result)
            {
                TempData["StatusMessage"] = "New category added succesfully";
                return RedirectToAction(nameof(Add));
            }
            ModelState.AddModelError("", $"{vm.Name} category has already been added");

            return View(vm);
        }
    }
}
