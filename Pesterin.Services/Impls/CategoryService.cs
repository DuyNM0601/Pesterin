using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pesterin.Core.Entities;
using Pesterin.Core.Repositories;
using Pesterin.Core.Uows;
using Pesterin.Services.Interface;
using Pesterin.Services.Maps;
using Pesterin.Services.Models.Categories;

namespace Pesterin.Services.Impls
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryRepository = _unitOfWork.CategoryRepository;
        }

        public async Task<CreateCategoryViewModel> CreateCategory(CreateCategoryViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var category = _mapper.Map<Category>(model);

            _categoryRepository.Add(category);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<CreateCategoryViewModel>(category);
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            return _mapper.Map<List<CategoryViewModel>>(await _categoryRepository.GetAll());
        }
    }
}
