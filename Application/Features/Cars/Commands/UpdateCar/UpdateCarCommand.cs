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

namespace Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public Color color { get; set; }
        public int DailyPrice { get; set; }
        public string ImageLink { get; set; }
        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Response<int>>
        {
            private readonly ICarRepositoryAsync _carRepository;
            private readonly IMapper _mapper;
            public UpdateCarCommandHandler(ICarRepositoryAsync carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
            {
                var car = await _carRepository.GetByIdAsync(command.Id);

                if (car == null)
                {
                    throw new ApiException($"Car Not Found.");
                }
                else
                {
                    car = _mapper.Map<Car>(command);
                    await _carRepository.UpdateAsync(car);
                    return new Response<int>(car.Id);
                }
            }
        }
    }
}
