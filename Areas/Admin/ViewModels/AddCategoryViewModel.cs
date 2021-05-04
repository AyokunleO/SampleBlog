using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBlog.Areas.Admin.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage ="Please enter category name")]
        [RegularExpression(@"[a-zA-Z\s]+", ErrorMessage = "Please enter a valid category name")]
        public string Name { get; set; }


        [DataType(DataType.MultilineText)]
        [RegularExpression(@"[a-zA-Z0-9 ]+",ErrorMessage ="Please enter a valid category description")]
        public string Description { get; set; }
    }
}
