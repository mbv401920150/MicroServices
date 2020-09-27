using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Book.App
{
    public class LibraryBookDto
    {
        public Guid? BookGuid { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Title { get; set; }

        public string AuthorBookGuid { get; set; }
    }
}
