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

namespace Application.Features.Rents.Queries.GetAllRents
{
    public class GetAllRentsQuery : IRequest<PagedResponse<IEnumerable<GetAllRentsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllRentsQueryHandler : IRequestHandler<GetAllRentsQuery, PagedResponse<IEnumerable<GetAllRentsViewModel>>>
    {
        private readonly IRentRepositoryAsync _rentRepository;
        private readonly IMapper _mapper;
        public GetAllRentsQueryHandler(IRentRepositoryAsync rentRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllRentsViewModel>>> Handle(GetAllRentsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllRentsParameter>(request);
            var rent = await _rentRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var rentViewModel = _mapper.Map<IEnumerable<GetAllRentsViewModel>>(rent);
            return new PagedResponse<IEnumerable<GetAllRentsViewModel>>(rentViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
