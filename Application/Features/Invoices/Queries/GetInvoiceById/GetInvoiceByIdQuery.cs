using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery : IRequest<Response<Invoice>>
    {
        public int Id { get; set; }
        public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Response<Invoice>>
        {
            private readonly IInvoiceRepositoryAsync _invoiceRepository;
            public GetInvoiceByIdQueryHandler(IInvoiceRepositoryAsync invoiceRepository)
            {
                _invoiceRepository = invoiceRepository;
            }
            public async Task<Response<Invoice>> Handle(GetInvoiceByIdQuery query, CancellationToken cancellationToken)
            {
                var invoice = await _invoiceRepository.GetByIdAsync(query.Id);
                if (invoice == null) throw new ApiException($"Invoice Not Found.");
                return new Response<Invoice>(invoice);
            }
        }
    }
}
