using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.DTOs
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string ArticleImageUrl { get; set; }
        public string AuthorImageUrl { get; set; }
    }
}
