using Microsoft.AspNetCore.Mvc;
using SampleBlog.Areas.Admin.ViewModels;
using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Repositories;
using SampleBlog.DAL.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IApplicationUserRepository applicationUserRepository;

        public DashboardController(IArticleRepository articleRepository, ICategoryRepository categoryRepository, IApplicationUserRepository applicationUserRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
            this.applicationUserRepository = applicationUserRepository;
        }
        public async Task<IActionResult> Index()
        {
            
            var vm = new DashboardViewModel
            {
                ArticlesCounter =  await articleRepository.GetAll(),
                CategoriesCounter = await categoryRepository.GetAll(),
                UsersCounter = await applicationUserRepository.GetAll()
            };
            return View(vm);
        }
    }
}
