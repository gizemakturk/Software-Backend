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

namespace Application.Features.Cars.Queries.GetCarById
{
    public class GetCarByIdQuery : IRequest<Response<Car>>
    {
        public int Id { get; set; }
        public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Response<Car>>
        {
            private readonly ICarRepositoryAsync _carRepository;
            public GetCarByIdQueryHandler(ICarRepositoryAsync carRepository)
            {
                _carRepository = carRepository;
            }
            public async Task<Response<Car>> Handle(GetCarByIdQuery query, CancellationToken cancellationToken)
            {
                var car = await _carRepository.GetByIdAsync(query.Id);
                if (car == null) throw new ApiException($"Car Not Found.");
                return new Response<Car>(car);
            }
        }
    }
}
