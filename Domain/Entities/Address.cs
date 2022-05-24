using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address : AuditableBaseEntity
    {
        public string City { get; set; }
        public string Town { get; set; }
    }
}
