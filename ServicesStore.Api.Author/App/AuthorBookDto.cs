using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.App
{
public class AuthorBookDto
{
    public string AuthorBookGuid { get; set; }

    public string AuthorName { get; set; }

    public string AuthorLastName { get; set; }

    public DateTime? AuthorBirthdate { get; set; }
}
}
