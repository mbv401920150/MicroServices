using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Book.Model
{
    public class LibraryBook
    {
        [Key]
        public int BookId { get; set; }

        public Guid? BookGuid { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Title { get; set; }

        public string AuthorBookGuid { get; set; }
    }
}
