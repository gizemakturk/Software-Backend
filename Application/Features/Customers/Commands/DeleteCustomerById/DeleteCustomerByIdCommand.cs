using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, Response<int>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;
            public DeleteCustomerByIdCommandHandler(ICustomerRepositoryAsync customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<Response<int>> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(command.Id);
                if (customer == null) throw new ApiException($"Customer Not Found.");
                await _customerRepository.DeleteAsync(customer);
                return new Response<int>(customer.Id);
            }
        }
    }
}
