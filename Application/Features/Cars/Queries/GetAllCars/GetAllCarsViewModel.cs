using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Cars.Queries.GetAllCars
{
    public class GetAllCarsViewModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public int DailyPrice { get; set; }
    }
}
