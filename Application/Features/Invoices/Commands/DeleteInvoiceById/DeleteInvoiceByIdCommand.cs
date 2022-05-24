using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.DeleteInvoiceById
{
    public class DeleteInvoiceByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteInvoiceByIdCommandHandler : IRequestHandler<DeleteInvoiceByIdCommand, Response<int>>
        {
            private readonly IInvoiceRepositoryAsync _invoiceRepository;
            public DeleteInvoiceByIdCommandHandler(IInvoiceRepositoryAsync invoiceRepository)
            {
                _invoiceRepository = invoiceRepository;
            }
            public async Task<Response<int>> Handle(DeleteInvoiceByIdCommand command, CancellationToken cancellationToken)
            {
                var invoice = await _invoiceRepository.GetByIdAsync(command.Id);
                if (invoice == null) throw new ApiException($"Invoice Not Found.");
                await _invoiceRepository.DeleteAsync(invoice);
                return new Response<int>(invoice.Id);
            }
        }
    }
}
