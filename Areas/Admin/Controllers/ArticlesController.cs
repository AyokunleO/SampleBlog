using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleBlog.Areas.Admin.ViewModels;
using SampleBlog.DAL.Models;
using SampleBlog.DAL.Repositories;
using SampleBlog.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUserService userService;
        private readonly IArticleRepository articleRepository;

        public ArticlesController(ICategoryRepository categoryRepository, IUserService userService, IArticleRepository articleRepository)
        {
            this.categoryRepository = categoryRepository;
            this.userService = userService;
            this.articleRepository = articleRepository;
        }
        public async Task<IActionResult> Index()
        {
            var vm = new ArticleIndexViewModel
            {
                Articles = await articleRepository.GetAll()
            };
            return View(vm);
        }
            
        


        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var vm = new AddArticleViewModel
            {
                Categories = await GetUICategories(),
                AuthorId = await userService.GetCurrentUserId()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddArticleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = await GetUICategories();
                return View(viewModel);
            }
              
            var article = new Article
            {
                Title = viewModel.Title,
                Body = viewModel.Body,
                CategoryId = Convert.ToInt32(viewModel.CategoryId),
                AuthorId = Convert.ToInt32(viewModel.AuthorId),
                ArticleImageUrl = viewModel.PostImageUrl
            };
            await articleRepository.Add(article);
            TempData["statusMessage"] = "New article added successfully";
            return RedirectToAction(nameof(Add));
        }
        [NonAction]
        public async Task<IEnumerable<SelectListItem>>GetUICategories()
         {
              var categories = await categoryRepository.GetAll();
            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString()
                ,
                Text = c.CategoryName
            });
         }
    }
}
