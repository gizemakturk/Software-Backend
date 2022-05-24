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
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Address PickupAddress { get; set; }
        public Address ReturnAddress { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; }
        public Invoice Invoice { get; set; }
    }
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Response<int>>
    {
        private readonly IRentRepositoryAsync _rentRepository;
        private readonly IMapper _mapper;
        public CreateRentCommandHandler(IRentRepositoryAsync rentRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRentCommand command, CancellationToken cancellationToken)
        {
            var rent = _mapper.Map<Rent>(command);
            await _rentRepository.AddAsync(rent);
            return new Response<int>(rent.Id);
        }
    }
}
