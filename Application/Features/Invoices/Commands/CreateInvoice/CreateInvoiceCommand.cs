using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.CreateInvoice
{
    public partial class CreateInvoiceCommand : IRequest<Response<int>>
    {
        public PaymentMethods PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Response<int>>
    {
        private readonly IInvoiceRepositoryAsync _invoiceRepository;
        private readonly IMapper _mapper;
        public CreateInvoiceCommandHandler(IInvoiceRepositoryAsync invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(command);
            await _invoiceRepository.AddAsync(invoice);
            return new Response<int>(invoice.Id);
        }
    }
}
