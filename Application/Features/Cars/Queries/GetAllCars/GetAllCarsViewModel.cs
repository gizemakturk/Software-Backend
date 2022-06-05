using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Cars.Queries.GetAllCars
{
    public class GetAllCarsViewModel
    {
        public int Id { get; set; }
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public Color color { get; set; }
        public int DailyPrice { get; set; }
        public string ImageLink { get; set; }
    }
}
