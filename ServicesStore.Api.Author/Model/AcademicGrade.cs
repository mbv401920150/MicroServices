using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.Model
{
    public class AcademicGrade
    {
        [Key]
        public int IdAcademicGrade { get; set; }

        public string AcademicGradeGuid { get; set; }

        public string AcademicGradeName { get; set; }

        public string AcademicCenter { get; set; }

        public DateTime? FinishedAt { get; set; }

        public int IdAuthorBook { get; set; }
        public AuthorBook AuthorBook { get; set; }
    }
}
