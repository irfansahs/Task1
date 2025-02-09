using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Task1.Application.Dtos;
using Task1.Domain.Entities;

namespace Task1.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateSupportFormDto, SupportForm>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }

}