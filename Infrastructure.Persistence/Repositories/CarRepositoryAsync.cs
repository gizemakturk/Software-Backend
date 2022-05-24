using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CarRepositoryAsync : GenericRepositoryAsync<Car>, ICarRepositoryAsync
    {
        private readonly DbSet<Car> _cars;

        public CarRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _cars = dbContext.Set<Car>();
        }
    }
}
