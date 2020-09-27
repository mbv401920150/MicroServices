using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.Author.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.Author.Persistence
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options) { 
        }

        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<AcademicGrade> AcademicGrades { get; set; }


    }
}
