using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WebServiceE.Entity
{
    [XmlRoot("xml")]
    public class xml
    {
        public xml() { }
        public xml(List<Produto> produto)
        {
            this.produto = produto;
        }
        public List<Produto> produto { get; set; }

        public Produto produtoXml(string texto)
        {
            Produto pro = new Produto();
            XElement xml = XElement.Parse(texto);
            pro.idt_func = xml.Attribute("idt_func").Value;
            pro.idt_func = xml.Attribute("nome").Value;
            pro.idt_func = xml.Attribute("descricao").Value;
            pro.idt_func = xml.Attribute("categoria").Value;
            pro.idt_func = xml.Attribute("modelo").Value;
            pro.idt_func = xml.Attribute("marca").Value;
            pro.idt_func = xml.Attribute("valor").Value;






            return pro;
        }
    }
}