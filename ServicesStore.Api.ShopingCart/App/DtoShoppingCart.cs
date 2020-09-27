using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.App
{
    public class DtoShoppingCart
    {
        public int ShopingCartSessionId { get; set; }

        public DateTime? CreationDate { get; set; }

        public List<DtoShoppingCartDetail> ListProducts { get; set; }
    }
}
