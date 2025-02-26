using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesterin.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string email, Guid id);
    }
}
