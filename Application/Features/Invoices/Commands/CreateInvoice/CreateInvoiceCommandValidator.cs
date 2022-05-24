using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        private readonly IInvoiceRepositoryAsync invoiceRepository;

        public CreateInvoiceCommandValidator(IInvoiceRepositoryAsync invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
                
        }
    }
}
