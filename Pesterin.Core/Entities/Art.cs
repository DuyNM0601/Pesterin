using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Core.Enums;

namespace Pesterin.Core.Entities
{
    public class Art
    {
        [Key]
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TypeArt Type { get; set; }
        public Category Category { get; set; }
        public Account Account { get; set; }
        public ArtStatus Status { get; set; }
    }
}
