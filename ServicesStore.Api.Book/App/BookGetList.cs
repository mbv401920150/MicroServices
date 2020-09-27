using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Book.Model;
using ServicesStore.Api.Book.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesStore.Api.Book.App
{
public class BookGetList
{
    public class RequestBookGetList : IRequest<List<LibraryBookDto>> { }

    public class HandlerBookGetList : IRequestHandler<RequestBookGetList, List<LibraryBookDto>>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public HandlerBookGetList(AppDbContext _context, IMapper _mapper) {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<LibraryBookDto>> Handle(RequestBookGetList request, CancellationToken cancellationToken)
        {
            var books = await context.LibraryBooks.ToListAsync();
            var result = mapper.Map<List<LibraryBook>, List<LibraryBookDto>>(books);

            return result;
        }
    }
}
}
