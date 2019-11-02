using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceE.Entity
{
    public class Item
    {
        public int id { get; set; }
        public int idPedido { get; set; }
        public int idProduto { get; set; }
        public int qtd { get; set; }
        public float valor { get; set; }
        public Produt produto { get; set; }
    }
}