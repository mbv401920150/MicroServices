using MediatR;
using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.ShopingCart.Persistence;
using ServicesStore.Api.ShopingCart.RemoteInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.App
{
    public class DtoQuery
    {
        public class Request : IRequest<DtoShoppingCart>
        {
            public int ShopingCartSessionId { get; set; }
        }

        public class Handler : IRequestHandler<Request, DtoShoppingCart>
        {
            private readonly AppDbContext _context;
            private readonly ILibraryBookService _bookService;

            public Handler(AppDbContext context, ILibraryBookService bookService)
            {
                _context = context;
                _bookService = bookService;
            }

            public async Task<DtoShoppingCart> Handle(Request request, CancellationToken cancellationToken)
            {
                var shoppingCart = await _context
                    .ShoppingCartSessions
                    .FirstOrDefaultAsync(x => x.ShopingCartSessionId == request.ShopingCartSessionId);

                var shoppingCartDetail = await _context
                    .ShoppingCartDetails
                    .Where(x => x.ShopingCartSessionId == request.ShopingCartSessionId)
                    .ToListAsync();

                List<DtoShoppingCartDetail> ListBooks = new List<DtoShoppingCartDetail>();

                foreach (var book in shoppingCartDetail)
                {
                    var response = await _bookService.GetBook(new Guid(book.SelectedProduct));

                    ListBooks.Add(new DtoShoppingCartDetail
                    {
                        BookGuid = response.Book.BookGuid,
                        AuthorBookGuid = response.Book.AuthorBookGuid,
                        PublishDate = response.Book.PublishDate,
                        Title = response.Book.Title
                    });
                }

                return new DtoShoppingCart()
                {
                    ShopingCartSessionId = shoppingCart.ShopingCartSessionId,
                    CreationDate = shoppingCart.CreationDate,
                    ListProducts = ListBooks
                };
            }
        }
    }
}
