using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBack_Web.Models
{
    public class ItemPedidoViewModel
    {
        public int PedidoId { get; set; }
        public Pedido pedido { get; set; }
        public ICollection<ItensPedido> ItensPedido { get; set; }
    }
}