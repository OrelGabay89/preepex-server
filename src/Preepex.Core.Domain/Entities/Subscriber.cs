using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preepex.Core.Domain.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; } // Add the 'Name' property
    }
}
