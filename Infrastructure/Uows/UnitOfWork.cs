using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Core.Repositories;
using Pesterin.Core.Uows;
using Pesterin.Infrastructure.Data;
using Pesterin.Infrastructure.Repositories;

namespace Pesterin.Infrastructure.Uows
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PesterinContext _context;
        public IAccountRepository AccountRepository {  get; private set; }
        public IPackageRepository PackageRepository { get; private set; }
        public IArtRepository ArtRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }

        public UnitOfWork(PesterinContext context)
        {
            _context = context;
            AccountRepository = new AccountRepository(_context);
            PackageRepository = new PackageRepository(_context);
            ArtRepository = new ArtRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
