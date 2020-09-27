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
public class GetListAuthorBook
{
    public class ListAuthorBook : IRequest<List<AuthorBookDto>> { }

    public class Handler : IRequestHandler<ListAuthorBook, List<AuthorBookDto>>
    {
        private readonly ContextAuthor context;
        private readonly IMapper mapper;

        public Handler(ContextAuthor _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<List<AuthorBookDto>> Handle(ListAuthorBook request, CancellationToken cancellationToken)
        {
            var listAuthors = await context.AuthorBooks.ToListAsync();
            var result = mapper.Map<List<AuthorBook>, List<AuthorBookDto>>(listAuthors);

            return result;
        }
    }
}
}
