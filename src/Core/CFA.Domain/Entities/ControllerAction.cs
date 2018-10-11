using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Domain.Interfaces;

namespace CFA.Domain.Entities
{
    public class ControllerAction : IEntity
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public int ControllerId { get; set; }

        public IList<Right> Rights { get; set; }
        public virtual Controller Controller { get; set; }
        public virtual Action Action { get; set; }

    }



}
