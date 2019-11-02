using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceE.Entity
{
    public class Pedido
    {
        public int id { get; set; }
        public float valor{ get; set; }
        public string status { get; set; }
        public List<Item> itens { get; set; }
    }
}