using MediatR;
using ServicesStore.Api.ShopingCart.Model;
using ServicesStore.Api.ShopingCart.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.App
{
    public class ShoppingCartNew
    {
        public class ShoppingCartRequest : IRequest
        {
            public DateTime CreationSessionDate { get; set; }

            public List<string> ProductList { get; set; }
        }

        public class ShoppingCartHandler : IRequestHandler<ShoppingCartRequest>
        {
            public readonly AppDbContext _context;
            public ShoppingCartHandler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShoppingCartRequest request, CancellationToken cancellationToken)
            {
                var shoppingCartSession = new ShoppingCartSession() { CreationDate = request.CreationSessionDate };

                _context.ShoppingCartSessions.Add(shoppingCartSession);

                var newRows = await _context.SaveChangesAsync();

                if (newRows == 0) throw new Exception("Something goes wrong creating the session");

                int sessionId = shoppingCartSession.ShopingCartSessionId;

                await _context.ShoppingCartDetails.AddRangeAsync(
                    request.ProductList.Select(p =>
                        new ShoppingCartDetail()
                        {
                            ShopingCartSessionId = sessionId,
                            CreationDate = request.CreationSessionDate,
                            SelectedProduct = p
                        }
                    ));

                newRows = await _context.SaveChangesAsync();

                if (newRows > 0) return Unit.Value;
                else throw new Exception("Something goes wrong with the insertion of the details");
            }
        }
    }
}
