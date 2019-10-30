using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceE.Entity
{
    public class Item
    {
        public int id { get; set; }
        public int qtd { get; set; }
        public float valor { get; set; }
        public Produto produto { get; set; }
    }
}