using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Invoices.Queries.GetAllInvoices
{
    public class GetAllInvoicesViewModel
    {
        public int Id { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
