using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceE.Entity
{
    public class Produt
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string categoria { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public float valor { get; set; }
        public float quantidade { get; set; }
    }
}