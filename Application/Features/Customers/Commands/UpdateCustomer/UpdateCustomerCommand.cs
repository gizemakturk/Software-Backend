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

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;
            private readonly IMapper _mapper;
            public UpdateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(command.Id);

                if (customer == null)
                {
                    throw new ApiException($"Customer Not Found.");
                }
                else
                {
                    customer = _mapper.Map<Customer>(command);
                    await _customerRepository.UpdateAsync(customer);
                    return new Response<int>(customer.Id);
                }
            }
        }
    }
}
