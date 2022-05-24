using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

    }
}
