using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<ArticleDTO> ArticlesCounter { get; set; } = new List<ArticleDTO>();
        public IEnumerable<CategoryDTO> CategoriesCounter { get; set; } = new List<CategoryDTO>();
        public IEnumerable<ApplicationUserDTO> UsersCounter { get; set; } = new List<ApplicationUserDTO>();
    }
}
