using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.CreateCar
{
    public partial class CreateCarCommand : IRequest<Response<int>>
    {
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string GearType { get; set; }
        public int NumberOfSeat { get; set; }
        public int DailyPrice { get; set; }
        public string ImageLink { get; set; }
    }
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Response<int>>
    {
        private readonly ICarRepositoryAsync _carRepository;
        private readonly IMapper _mapper;
        public CreateCarCommandHandler(ICarRepositoryAsync carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(command);
            await _carRepository.AddAsync(car);
            return new Response<int>(car.Id);
        }
    }
}
