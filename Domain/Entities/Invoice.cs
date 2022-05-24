using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;



namespace Domain.Entities
{
    public class Invoice : AuditableBaseEntity
    {
        public PaymentMethods PaymentMethod{ get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int RentId { get; set; }
        public Rent Rent { get; set; }
    }
    public enum PaymentMethods
    {
        CreditCard,
        Cash
    }
}
