using SampleBlog.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Service
{
    public interface IUserService
    {
         Task<int> GetCurrentUserId();
    }
}
