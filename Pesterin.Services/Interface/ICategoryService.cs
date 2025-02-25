using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Services.Models.Categories;

namespace Pesterin.Services.Interface
{
    public interface ICategoryService
    {
        Task<CreateCategoryViewModel> CreateCategory(CreateCategoryViewModel model);
        Task<List<CategoryViewModel>> GetAll();
    }
}
