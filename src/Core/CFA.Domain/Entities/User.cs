using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using CFA.Domain.Interfaces;

namespace CFA.Domain.Entities
{
    public class User : IEntity
    {                
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Username { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }


    }




}
