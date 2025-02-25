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
using Pesterin.Services.Models.Arts;

namespace Pesterin.Services.Impls
{
    public class ArtService : IArtService
    {
        private readonly IArtRepository _artRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uows;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAccountRepository _accountRepository;
        public ArtService(IUnitOfWork uows, IMapper mapper)
        {
            _uows = uows;
            _artRepository = _uows.ArtRepository;
            _categoryRepository = _uows.CategoryRepository;
            _accountRepository = _uows.AccountRepository;
            _mapper = mapper;
        }

        public async Task<List<ArtViewModel>> GetAll(int pageIndex, int pageSize)
        {
            var art = await _artRepository.GetAll(pageIndex, pageSize);
            return _mapper.Map<List<ArtViewModel>>(art);
        }

        public async Task<CreateArtViewModel> Create(CreateArtViewModel model)
        {
            var checkCategory = _categoryRepository.GetById(model.CategoryId);

            if (checkCategory == null)
            {
                throw new Exception("Category does not exist");
            }

            var checkAccount = _accountRepository.GetById(model.AccountId);

            if (checkAccount == null)
            {
                throw new ArgumentException("Account does not exist");
            }

            var art = _mapper.Map<Art>(model);

            art.Account = checkAccount;
            art.Category = checkCategory;

            _artRepository.Add(art);
            await _uows.SaveChangeAsync();

            return _mapper.Map<CreateArtViewModel>(model);
        }
    }
}
