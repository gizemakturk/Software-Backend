using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Rents.Commands.DeleteRentById
{
    public class DeleteRentByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteRentByIdCommandHandler : IRequestHandler<DeleteRentByIdCommand, Response<int>>
        {
            private readonly IRentRepositoryAsync _rentRepository;
            public DeleteRentByIdCommandHandler(IRentRepositoryAsync rentRepository)
            {
                _rentRepository = rentRepository;
            }
            public async Task<Response<int>> Handle(DeleteRentByIdCommand command, CancellationToken cancellationToken)
            {
                var rent = await _rentRepository.GetByIdAsync(command.Id);
                if (rent == null) throw new ApiException($"Rent Not Found.");
                await _rentRepository.DeleteAsync(rent);
                return new Response<int>(rent.Id);
            }
        }
    }
}
