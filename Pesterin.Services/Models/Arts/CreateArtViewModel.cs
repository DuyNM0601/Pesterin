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
    public class CreateArtViewModel
    {
        [Required(ErrorMessage = "Url is not empty")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Tittle is not empty")]
        [StringLength(100, ErrorMessage = "Tittle must not exceed 500 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is not empty")]
        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Type is not empty")]
        public TypeArt Type { get; set; }

        public ArtStatus Status { get; set; }

        [Required(ErrorMessage = "CategoryId is not empty")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "AccountId is not empty")]
        public Guid AccountId { get; set; }
    }
}
