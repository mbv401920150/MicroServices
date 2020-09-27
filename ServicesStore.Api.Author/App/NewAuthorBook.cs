using FluentValidation;
using MediatR;
using ServicesStore.Api.Author.Model;
using ServicesStore.Api.Author.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.App
{
    public class NewAuthorBook
    {
        public class Execute : IRequest
        {
            public string AuthorName { get; set; }
            public string AuthorLastName { get; set; }

            public DateTime? AuthorBirthdate { get; set; }

            public string AuthorBookGuid = Convert.ToString(Guid.NewGuid());
        }

        public class Validation : AbstractValidator<Execute>
        {
            public Validation()
            {
                RuleFor(r => r.AuthorName).NotEmpty();
                RuleFor(r => r.AuthorLastName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly ContextAuthor context;

            public Handler(ContextAuthor _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var newEntry = new AuthorBook
                {
                    AuthorName = request.AuthorName,
                    AuthorBookGuid = request.AuthorBookGuid,
                    AuthorLastName = request.AuthorLastName,
                    AuthorBirthdate = request.AuthorBirthdate
                };

                await context.AuthorBooks.AddAsync(newEntry);

                var result = await context.SaveChangesAsync();

                if (result > 0)
                    return Unit.Value;

                throw new Exception("Some problem happen with the insertation of a new entry");
            }
        }
    }
}
