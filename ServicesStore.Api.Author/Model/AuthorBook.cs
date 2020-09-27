using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.Model
{
    public class AuthorBook
    {
        [Key]
        public int IdAuthorBook { get; set; }

        public string AuthorBookGuid { get; set; }

        public string AuthorName { get; set; }

        public string AuthorLastName { get; set; }

        public DateTime? AuthorBirthdate { get; set; }

        public ICollection<AcademicGrade> AcademicGradeList { get; set; }
    }
}
