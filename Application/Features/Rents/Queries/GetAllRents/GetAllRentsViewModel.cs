using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Rents.Queries.GetAllRents
{
    public class GetAllRentsViewModel
    {
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Address PickupAddress { get; set; }
        public Address ReturnAddress { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; }
        public Invoice Invoice { get; set; }
    }
}
