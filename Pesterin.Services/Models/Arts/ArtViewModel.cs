using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Core.Entities;
using Pesterin.Core.Enums;

namespace Pesterin.Services.Models.Arts
{
    public class ArtViewModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TypeArt Type { get; set; }
        public Category Category { get; set; }
        public Account Account { get; set; }
    }
}
