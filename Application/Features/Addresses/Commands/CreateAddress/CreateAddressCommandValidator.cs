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

namespace Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        private readonly IAddressRepositoryAsync addressRepository;

        public CreateAddressCommandValidator(IAddressRepositoryAsync addressRepository)
        {
            this.addressRepository = addressRepository;

   
        }

    
    }
}
