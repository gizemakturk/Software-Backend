using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.DeleteCarById
{
    public class DeleteCarByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCarByIdCommandHandler : IRequestHandler<DeleteCarByIdCommand, Response<int>>
        {
            private readonly ICarRepositoryAsync _carRepository;
            public DeleteCarByIdCommandHandler(ICarRepositoryAsync carRepository)
            {
                _carRepository = carRepository;
            }
            public async Task<Response<int>> Handle(DeleteCarByIdCommand command, CancellationToken cancellationToken)
            {
                var car = await _carRepository.GetByIdAsync(command.Id);
                if (car == null) throw new ApiException($"Car Not Found.");
                await _carRepository.DeleteAsync(car);
                return new Response<int>(car.Id);
            }
        }
    }
}
