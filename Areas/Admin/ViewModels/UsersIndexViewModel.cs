using SampleBlog.DAL.DTOs;
using SampleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.ViewModels
{
    public class UsersIndexViewModel
    {
        public IEnumerable<ApplicationUserDTO> Users { get; set; } = new List<ApplicationUserDTO>();
    }
}
