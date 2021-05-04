using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUserDTO>> GetAll();
        Task<ApplicationUserDTO> Find(int id);
        Task Add(ApplicationUser user);
        Task<ApplicationUser> Remove(int id);
    }
}
