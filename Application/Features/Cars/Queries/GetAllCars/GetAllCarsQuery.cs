using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetAllCars
{
    public class GetAllCarsQuery : IRequest<PagedResponse<IEnumerable<GetAllCarsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, PagedResponse<IEnumerable<GetAllCarsViewModel>>>
    {
        private readonly ICarRepositoryAsync _carRepository;
        private readonly IMapper _mapper;
        public GetAllCarsQueryHandler(ICarRepositoryAsync carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCarsViewModel>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllCarsParameter>(request);
            var car = await _carRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var carViewModel = _mapper.Map<IEnumerable<GetAllCarsViewModel>>(car);
            return new PagedResponse<IEnumerable<GetAllCarsViewModel>>(carViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
