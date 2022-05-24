using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Response<int>>
        {
            private readonly IInvoiceRepositoryAsync _invoiceRepository;
            private readonly IMapper _mapper;
            public UpdateInvoiceCommandHandler(IInvoiceRepositoryAsync invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateInvoiceCommand command, CancellationToken cancellationToken)
            {
                var invoice = await _invoiceRepository.GetByIdAsync(command.Id);

                if (invoice == null)
                {
                    throw new ApiException($"Invoice Not Found.");
                }
                else
                {
                    invoice = _mapper.Map<Invoice>(command);
                    await _invoiceRepository.UpdateAsync(invoice);
                    return new Response<int>(invoice.Id);
                }
            }
        }
    }
}
