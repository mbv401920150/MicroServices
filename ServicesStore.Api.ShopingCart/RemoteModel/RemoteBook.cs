using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.RemoteModel
{
    public class RemoteLibraryBook
    {
        public int BookId { get; set; }

        public Guid? BookGuid { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Title { get; set; }

        public string AuthorBookGuid { get; set; }
    }
}
