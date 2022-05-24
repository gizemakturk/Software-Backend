using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Customer : User
    {
        public bool Status { get; set; }
    }
}
