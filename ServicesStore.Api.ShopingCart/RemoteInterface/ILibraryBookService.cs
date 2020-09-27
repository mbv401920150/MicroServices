using ServicesStore.Api.ShopingCart.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.RemoteInterface
{
    public interface ILibraryBookService
    {
        Task<(bool Result, RemoteLibraryBook Book, string errorMessage)> GetBook(Guid BookId);
    }
}
