using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.Model
{
    public class ShoppingCartDetail
    {
        [Key]
        public int ShoppingCartDetailId { get; set; }

        public DateTime? CreationDate { get; set; }

        public string SelectedProduct { get; set; }

        public int ShopingCartSessionId { get; set; }
        public ShoppingCartSession ShoppingCartSession { get; set; }
    }
}
