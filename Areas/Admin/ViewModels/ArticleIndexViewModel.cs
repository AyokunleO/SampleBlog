using SampleBlog.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.ViewModels
{
    public class ArticleIndexViewModel
    {
        public IEnumerable<ArticleDTO> Articles { get; set; } = new List<ArticleDTO>();
    }
}
