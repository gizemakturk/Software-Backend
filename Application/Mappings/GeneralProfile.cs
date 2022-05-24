using Application.Features.Addresses.Commands.CreateAddress;
using Application.Features.Addresses.Commands.UpdateAddress;
using Application.Features.Addresses.Queries.GetAllAddresses;
using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Queries.GetAllCars;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Queries.GetAllCustomers;
using Application.Features.Invoices.Commands.CreateInvoice;
using Application.Features.Invoices.Commands.UpdateInvoice;
using Application.Features.Invoices.Queries.GetAllInvoices;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Rents.Commands.CreateRent;
using Application.Features.Rents.Commands.UpdateRent;
using Application.Features.Rents.Queries.GetAllRents;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<Car, GetAllCarsViewModel>().ReverseMap();
            CreateMap<CreateCarCommand, Car>();
            CreateMap<GetAllCarsQuery, GetAllCarsParameter>();
            CreateMap<UpdateCarCommand, Car>();

            CreateMap<Address, GetAllAddressesViewModel>().ReverseMap();
            CreateMap<CreateAddressCommand, Address>();
            CreateMap<GetAllAddressesQuery, GetAllAddressesParameter>();
            CreateMap<UpdateAddressCommand, Address>();

            CreateMap<Customer, GetAllCustomersViewModel>().ReverseMap();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<GetAllCustomersQuery, GetAllCustomersParameter>();
            CreateMap<UpdateCustomerCommand, Customer>();

            CreateMap<Invoice, GetAllInvoicesViewModel>().ReverseMap();
            CreateMap<CreateInvoiceCommand, Invoice>();
            CreateMap<GetAllInvoicesQuery, GetAllInvoicesParameter>();
            CreateMap<UpdateInvoiceCommand, Invoice>();

            CreateMap<Rent, GetAllRentsViewModel>().ReverseMap();
            CreateMap<CreateRentCommand, Rent>();
            CreateMap<GetAllRentsQuery, GetAllRentsParameter>();
            CreateMap<UpdateRentCommand, Rent>();


        }
    }
}
