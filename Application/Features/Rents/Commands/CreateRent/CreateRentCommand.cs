using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Rents.Commands.CreateRent
{
    public partial class CreateRentCommand : IRequest<Response<int>>
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int PickupAddressId { get; set; }
        public int ReturnAddressId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; }
        public int InvoiceId { get; set; }
    }
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Response<int>>
    {
        private readonly IRentRepositoryAsync _rentRepository;
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly ICarRepositoryAsync _carRepository;
        private readonly IAddressRepositoryAsync _addressRepository;
        private readonly IInvoiceRepositoryAsync _invoiceRepository;
        private readonly IMapper _mapper;

        public CreateRentCommandHandler(IRentRepositoryAsync rentRepository, ICustomerRepositoryAsync customerRepository, ICarRepositoryAsync carRepository, IAddressRepositoryAsync addressRepository, IInvoiceRepositoryAsync invoiceRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _customerRepository = customerRepository;
            _carRepository = carRepository;
            _addressRepository = addressRepository;
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRentCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(command.CustomerId);
            if (customer == null) return null;

            var car = await _carRepository.GetByIdAsync(command.CarId);
            if (car == null) return null;

            var invoice = await _invoiceRepository.GetByIdAsync(command.InvoiceId);
            if (invoice == null) return null;

            var pickUpAddress = await _addressRepository.GetByIdAsync(command.PickupAddressId);
            if (pickUpAddress == null) return null;

            var returnAddress = await _addressRepository.GetByIdAsync(command.ReturnAddressId);
            if (returnAddress == null) return null;

            var rent = _mapper.Map<Rent>(command);
            rent.CarId = car.Id;
            rent.CustomerId = customer.Id;
            rent.PickupAddressId = pickUpAddress.Id;
            rent.ReturnAddressId = returnAddress.Id;
            rent.InvoiceId = invoice.Id;

            await _rentRepository.AddAsync(rent);
            return new Response<int>(rent.Id);
        }
    }
}
