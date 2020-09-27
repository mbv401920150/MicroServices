using AutoMapper;
using ServicesStore.Api.Book.App;
using ServicesStore.Api.Book.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesStore.Api.Book.Test
{
    public class MappingTest : Profile
    {
        public MappingTest() {
            CreateMap<LibraryBook, LibraryBookDto>();
        }
    }
}
