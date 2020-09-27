using AutoMapper;
using ServicesStore.Api.Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Book.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<LibraryBook, LibraryBookDto>();
        }
    }
}
