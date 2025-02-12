using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pesterin.Core.Enums;

namespace Pesterin.Core.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public AccountStatus Status { get; set; }
        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public ICollection<Art> Arts { get; set; }
    }
}
