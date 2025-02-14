using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Core.Repositories;

namespace Pesterin.Core.Uows
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        IArtRepository ArtRepository { get; }
        IPackageRepository PackageRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
