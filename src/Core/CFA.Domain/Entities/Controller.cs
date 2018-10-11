﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CFA.Domain.Entities
{
    public class Controller : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(350)]
        public string Description { get; set; }

        public virtual IList<ControllerAction> ControllerActions { get; set; }
    }


}
