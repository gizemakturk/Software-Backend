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

namespace Application.Features.Rents.Commands.UpdateRent
{
    public class UpdateRentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int PickupAddressId { get; set; }
        public int ReturnAddressId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, Response<int>>
        {
            private readonly IRentRepositoryAsync _rentRepository;
            private readonly IMapper _mapper;
            public UpdateRentCommandHandler(IRentRepositoryAsync rentRepository, IMapper mapper)
            {
                _rentRepository = rentRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateRentCommand command, CancellationToken cancellationToken)
            {
                var rent = await _rentRepository.GetByIdAsync(command.Id);

                if (rent == null)
                {
                    throw new ApiException($"Rent Not Found.");
                }
                else
                {
                    rent = _mapper.Map<Rent>(command);
                    await _rentRepository.UpdateAsync(rent);
                    return new Response<int>(rent.Id);
                }
            }
        }
    }
}
