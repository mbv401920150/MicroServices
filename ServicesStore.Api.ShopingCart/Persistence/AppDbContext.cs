using Microsoft.EntityFrameworkCore;
using ServicesStore.Api.ShopingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.Persistence
{
    /// <summary> DbContext to connect EF to a DB engine </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ShoppingCartSession> ShoppingCartSessions { get; set; }

        public DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; }
    }
}
