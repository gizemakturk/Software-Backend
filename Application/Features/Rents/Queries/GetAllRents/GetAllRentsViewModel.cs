using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Rents.Queries.GetAllRents
{
    public class GetAllRentsViewModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int PickupAddressId { get; set; }
        public int ReturnAddressId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; }
        public int InvoiceId { get; set; }
    }
}
