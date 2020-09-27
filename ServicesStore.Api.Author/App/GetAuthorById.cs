using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Author.Model;
using ServicesStore.Api.Author.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.App
{
    public class GetAuthorById
    {
        public class Request : IRequest<AuthorBookDto>
        {
            public string AuthorBookGuid { get; set; }

        }

        public class Handler : IRequestHandler<Request, AuthorBookDto>
        {
            private readonly ContextAuthor context;
            private readonly IMapper mapper;

            public Handler(ContextAuthor _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task<AuthorBookDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var author = await context.AuthorBooks.Where(a => a.AuthorBookGuid == request.AuthorBookGuid).FirstOrDefaultAsync();

                return mapper.Map<AuthorBook, AuthorBookDto>(author);
            }
        }
    }
}
