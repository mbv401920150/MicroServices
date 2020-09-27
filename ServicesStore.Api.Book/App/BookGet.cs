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
    public class BookGet
    {
        public class RequestBookGet : IRequest<LibraryBookDto>
        {
            public Guid? LibraryBookGuid { get; set; }
        }

        public class HandlerBookGet : IRequestHandler<RequestBookGet, LibraryBookDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public HandlerBookGet(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LibraryBookDto> Handle(RequestBookGet request, CancellationToken cancellationToken)
            {
                var book = await _context.LibraryBooks.Where(b => b.BookGuid == request.LibraryBookGuid).FirstOrDefaultAsync();

                if (book == null) throw new Exception("The book was not found");

                var bookDto = _mapper.Map<LibraryBook, LibraryBookDto>(book);

                return bookDto;
            }
        }
    }
}
