using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodBack_Web.Models
{
    public class ItensPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Quantidade { get; set; }

        public int ProdutoId { get; set; }

        public int PedidoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }
    }
}