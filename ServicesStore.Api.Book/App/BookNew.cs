using FluentValidation;
using MediatR;
using ServicesStore.Api.Book.Model;
using ServicesStore.Api.Book.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesStore.Api.Book.App
{
    public class BookNew
    {
        public class RequestBookNew : IRequest
        {
            public DateTime? PublishDate { get; set; }

            public string Title { get; set; }

            public string AuthorBookGuid { get; set; }

            public Guid BookGuid = Guid.NewGuid();
        }

        public class ValidationBookNew : AbstractValidator<RequestBookNew>
        {
            public ValidationBookNew()
            {
                RuleFor(b => b.Title).NotEmpty();
                RuleFor(b => b.AuthorBookGuid).NotEmpty();
            }
        }

        public class HandlerBookNew : IRequestHandler<RequestBookNew>
        {
            private readonly AppDbContext context;

            public HandlerBookNew(AppDbContext _context)
            {
                context = _context;
            }

            public async Task<Unit> Handle(RequestBookNew request, CancellationToken cancellationToken)
            {
                var newBook = new LibraryBook
                {
                    Title = request.Title,
                    AuthorBookGuid = request.AuthorBookGuid,
                    PublishDate = request.PublishDate,
                    BookGuid = request.BookGuid
                };

                await context.LibraryBooks.AddAsync(newBook);

                var newEntries = await context.SaveChangesAsync();

                if (newEntries > 0) return Unit.Value;

                throw new Exception("Something goes wrong adding a new entry");
            }
        }
    }
}
