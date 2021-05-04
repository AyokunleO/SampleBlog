using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ArticleDTO> SliderArticles { get; set; } = new List<ArticleDTO>();
        public IEnumerable<ArticleDTO> BodyArticles { get; set; } = new List<ArticleDTO>();

        public IEnumerable<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
