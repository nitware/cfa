using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Interfaces;

namespace CFA.Domain.Entities
{
    public class Right : IEntity
    {
        //public Right()
        //{
        //    Roles = new HashSet<Role>();
        //}

        public int Id { get; set; }
        public int ControllerActionId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(350)]
        public string Description { get; set; }

        public virtual ControllerAction ControllerAction { get; set; }
        public IList<Role> Roles { get; set; }

    }
}
