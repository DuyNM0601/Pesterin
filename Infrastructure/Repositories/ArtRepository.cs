using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Core.Entities;
using Pesterin.Core.Repositories;
using Pesterin.Infrastructure.Data;
using Pesterin.Infrastructure.Repositories.Base;

namespace Pesterin.Infrastructure.Repositories
{
    public class ArtRepository : Repository<Art>, IArtRepository
    {
        public ArtRepository(PesterinContext context) : base(context) { }
    }
}
