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

namespace Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<Customer>>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<Customer>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;
            public GetCustomerByIdQueryHandler(ICustomerRepositoryAsync customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<Response<Customer>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(query.Id);
                if (customer == null) throw new ApiException($"Customer Not Found.");
                return new Response<Customer>(customer);
            }
        }
    }
}
