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

namespace Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        private readonly ICarRepositoryAsync carRepository;

        public CreateCarCommandValidator(ICarRepositoryAsync carRepository)
        {
            this.carRepository = carRepository;
        }
    }
}
