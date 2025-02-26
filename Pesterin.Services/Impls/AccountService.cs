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
using Pesterin.Services.Models.Accounts;

namespace Pesterin.Services.Impls
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AccountService(IUnitOfWork uow, IMapper mapper, ITokenService tokenService)
        {
            _uow = uow;
            _accountRepository = _uow.AccountRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<List<AccountViewModel>> getAllAccount()
        {
            var accounts = await _accountRepository.GetAll();

            return _mapper.Map<List<AccountViewModel>>(accounts);
        }

        public async Task<string> GetAccount(string email, string password)
        {
            var checkAccount = _accountRepository.FirstOrDefault(a => a.Email == email
                && a.Password == password);

            if (checkAccount == null)
            {
                throw new UnauthorizedAccessException("Email or Password is wrong");
            }

            return _tokenService.GenerateToken(email, checkAccount.Id);
        }
    }
}
