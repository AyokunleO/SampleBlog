using SampleBlog.DAL.Models;
using SampleBlog.DAL.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Repositories
{
   public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> Find(int id);
        Task<bool> Add(Category user);
        Task<Category> Remove(int id);
    }
}
