using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceE.Entity
{
    public class Produto
    {
        [XmlElement("idt_func")]
        public string idt_func { get; set; }

        [XmlElement("nome")]
        public string nome_func { get; set; }

        [XmlElement("descricao")]
        public string descricao_func { get; set; }

        [XmlElement("categoria")]
        public string categoria_func { get; set; }

        [XmlElement("modelo")]
        public string modelo_func { get; set; }

        [XmlElement("marca")]
        public string marca_func { get; set; }

        [XmlElement("valor")]
        public string valor_func { get; set; }

        [XmlElement("quantidade")]
        public string quantidade_func { get; set; }
    }
}