using Swiftrade.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiftrade.Core.Domain.Entities
{
    public class Subscriber : BaseEntity<int>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; } // Add the 'Name' property
    }
}
