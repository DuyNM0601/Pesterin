using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Core.Entities;
using Pesterin.Services.Models;
using Pesterin.Services.Models.Accounts;

namespace Pesterin.Services.Interface
{
    public interface IAccountService
    {
        Task<List<AccountViewModel>> getAllAccount();
    }
}
