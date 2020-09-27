using AutoMapper;
using ServicesStore.Api.Author.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorBook, AuthorBookDto>();
        }
    }
}
