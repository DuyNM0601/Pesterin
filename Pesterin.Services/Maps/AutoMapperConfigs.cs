using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pesterin.Core.Entities;
using Pesterin.Services.Models.Accounts;

namespace Pesterin.Services.Maps
{
    public class AutoMapperConfigs : Profile
    {

        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(x =>
            {
                x.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod!.IsAssembly;
                x.AddProfile<AutoMapperConfigs>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => Lazy.Value;
        public AutoMapperConfigs()
        {
            CreateMap<Account, AccountViewModel>().ReverseMap();
        }
    }
}
