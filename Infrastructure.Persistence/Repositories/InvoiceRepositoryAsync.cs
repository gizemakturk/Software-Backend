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
    public class InvoiceRepositoryAsync : GenericRepositoryAsync<Invoice>, IInvoiceRepositoryAsync
    {
        private readonly DbSet<Invoice> _invoices;

        public InvoiceRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _invoices = dbContext.Set<Invoice>();
        }
    }
}
