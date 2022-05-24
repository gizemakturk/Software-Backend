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

namespace Application.Features.Rents.Queries.GetRentById
{
    public class GetRentByIdQuery : IRequest<Response<Rent>>
    {
        public int Id { get; set; }
        public class GetRentByIdQueryHandler : IRequestHandler<GetRentByIdQuery, Response<Rent>>
        {
            private readonly IRentRepositoryAsync _rentRepository;
            public GetRentByIdQueryHandler(IRentRepositoryAsync rentRepository)
            {
                _rentRepository = rentRepository;
            }
            public async Task<Response<Rent>> Handle(GetRentByIdQuery query, CancellationToken cancellationToken)
            {
                var rent = await _rentRepository.GetByIdAsync(query.Id);
                if (rent == null) throw new ApiException($"Rent Not Found.");
                return new Response<Rent>(rent);
            }
        }
    }
}
