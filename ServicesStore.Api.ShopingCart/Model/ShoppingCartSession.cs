using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.Model
{
    public class ShoppingCartSession
    {
        [Key]
        public int ShopingCartSessionId { get; set; }

        public DateTime? CreationDate { get; set; }

        public List<ShoppingCartDetail> ShoppingCartDetail { get; set; }
    }
}
