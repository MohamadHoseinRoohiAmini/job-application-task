using AutoMapper;
using Mc2.CrudTest.Domain.Customer.Dtoes;
using Mc2.CrudTest.Domain.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer,CustomerDto>().ReverseMap();
        }
    }
}
