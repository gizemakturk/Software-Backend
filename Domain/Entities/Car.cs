using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Car : AuditableBaseEntity
    {
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string GearType { get; set; }
        public int NumberOfSeat { get; set; }
        public int DailyPrice { get; set; }
        public string ImageLink { get; set; }

        // TODO: Status for availability
    }
}
