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

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<PagedResponse<IEnumerable<GetAllCustomersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<IEnumerable<GetAllCustomersViewModel>>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomersQueryHandler(ICustomerRepositoryAsync customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCustomersViewModel>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCustomersParameter>(request);
            var customer = await _customerRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var customerViewModel = _mapper.Map<IEnumerable<GetAllCustomersViewModel>>(customer);
            return new PagedResponse<IEnumerable<GetAllCustomersViewModel>>(customerViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
