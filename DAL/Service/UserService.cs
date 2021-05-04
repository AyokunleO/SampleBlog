using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.DAL.Service
{
    public class UserService : IUserService
    {
        private static Random random = new Random();
        private readonly IApplicationUserRepository userRepository;

        public UserService(IApplicationUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> GetCurrentUserId()
        {
            var totalUsers = (await userRepository.GetAll()).Count();
            var currentId = random.Next(1, totalUsers);

            return currentId;
        }
    }
}
