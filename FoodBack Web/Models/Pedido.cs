using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodBack_Web.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public float Quantidade { get; set; }
        public float ValorUnitario { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual Produto Produto { get; set; }
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public virtual Restaurante Restaurante { get; set; }
        [ForeignKey("Restaurante")]
        public int RestauranteId { get; set; }        


    }
}