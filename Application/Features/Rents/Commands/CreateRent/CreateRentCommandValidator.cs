using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Rents.Commands.CreateRent
{
    public class CreateRentCommandValidator : AbstractValidator<CreateRentCommand>
    {
        private readonly IRentRepositoryAsync rentRepository;

        public CreateRentCommandValidator(IRentRepositoryAsync rentRepository)
        {
            this.rentRepository = rentRepository;                
        }
    }
}
