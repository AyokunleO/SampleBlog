using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Repositories
{
   public interface IArticleRepository
    {
        Task<IEnumerable<ArticleDTO>> GetAll(int num = 20);
        Task<ArticleDTO> Find(int id);
        Task Add(Article user);
        Task<Article> Remove(int id);
    }
}
