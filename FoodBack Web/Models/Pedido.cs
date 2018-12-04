using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodBack_Web.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }    
        
        public virtual Restaurante Restaurantes { get; set; }
        public int RestauranteId { get; set; }
        public DateTime DataPedido { get; set; }

        [ForeignKey("RestauranteId")]
        public Restaurante Restaurante { get; set; }

        public virtual ICollection <ItensPedido> ItemPedidos { get; set; }
    }
}