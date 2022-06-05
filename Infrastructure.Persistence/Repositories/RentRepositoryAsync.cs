using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class RentRepositoryAsync : GenericRepositoryAsync<Rent>, IRentRepositoryAsync
    {
        private readonly DbSet<Rent> _rents;

        public RentRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _rents = dbContext.Set<Rent>();
        }
    }
}
