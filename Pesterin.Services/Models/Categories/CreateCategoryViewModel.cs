using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesterin.Services.Models.Categories
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Name is not empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is not empty")]
        public string Description { get; set; }
    }
}
