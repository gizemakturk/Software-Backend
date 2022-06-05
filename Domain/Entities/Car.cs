using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Car : AuditableBaseEntity
    {
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public int DailyPrice { get; set; }
        public string ImageLink { get; set; }
        public ICollection<Rent> Rents { get; set; }


        // TODO: Status for availability
    }
    public enum Color
    {
        black,white,red,orange,brown,blue,yellow,gray ,magenta,cyan,magentayellow 
    }
}
