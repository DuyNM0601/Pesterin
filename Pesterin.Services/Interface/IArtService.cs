using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Services.Models.Arts;

namespace Pesterin.Services.Interface
{
    public interface IArtService
    {
        Task<CreateArtViewModel> Create(CreateArtViewModel model);
    }
}
