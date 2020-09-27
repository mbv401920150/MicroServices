using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServicesStore.Api.Author.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.App
{
    public class AuthorBookDelete
    {
        public class AuthorBookDeleteRequest : IRequest
        {
            public string id { get; set; }
        }

        public class AuthorBookDeleteHandler : IRequestHandler<AuthorBookDeleteRequest>
        {
            private readonly ContextAuthor _context;
            public AuthorBookDeleteHandler(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(AuthorBookDeleteRequest request, CancellationToken cancellationToken)
            {
                try
                {
                    _context.AuthorBooks
                        .RemoveRange(_context.AuthorBooks.Where(x => x.AuthorBookGuid == request.id));

                    await _context.SaveChangesAsync();

                    return Unit.Value;
                }
                catch { throw; }
            }
        }
    }
}
