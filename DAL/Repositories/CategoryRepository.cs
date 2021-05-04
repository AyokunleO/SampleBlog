using Microsoft.EntityFrameworkCore;
using SampleBlog.DAL.Models;
using SampleBlog.DAL.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDbContext dbContext;

        public CategoryRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Add(Category category)
        {
            if (!await CheckDuplicate(category.CategoryName))
            {
                await dbContext.Categories.AddAsync(category);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CategoryDTO> Find(int id)
        {
            return await dbContext.Categories.Where(c => c.Id == id).Include(c => c.Articles).Select(c => new CategoryDTO { 
                Id = c.Id,
                CategoryName = c.CategoryName,
                Description = c.Description,
                NumberOfArticles = c.Articles.Count
            }).FirstOrDefaultAsync();          
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return await dbContext.Categories.Include(c => c.Articles).Select(c => new CategoryDTO {
                Id = c.Id,
            CategoryName = c.CategoryName,
            Description= c.Description,
            NumberOfArticles = c.Articles.Count
            }).ToListAsync();
        }

        public async Task<Category> Remove(int id)
        {
            Category category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        private async Task<bool> CheckDuplicate(string CategoryName)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == CategoryName);
            if (category != null)
                return true;

            return false;
        }
    }
}
