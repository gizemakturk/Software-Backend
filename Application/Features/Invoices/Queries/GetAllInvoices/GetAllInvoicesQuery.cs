using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Queries.GetAllInvoices
{
    public class GetAllInvoicesQuery : IRequest<PagedResponse<IEnumerable<GetAllInvoicesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, PagedResponse<IEnumerable<GetAllInvoicesViewModel>>>
    {
        private readonly IInvoiceRepositoryAsync _invoiceRepository;
        private readonly IMapper _mapper;
        public GetAllInvoicesQueryHandler(IInvoiceRepositoryAsync invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllInvoicesViewModel>>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllInvoicesParameter>(request);
            var invoice = await _invoiceRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var invoiceViewModel = _mapper.Map<IEnumerable<GetAllInvoicesViewModel>>(invoice);
            return new PagedResponse<IEnumerable<GetAllInvoicesViewModel>>(invoiceViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
