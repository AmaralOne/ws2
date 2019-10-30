using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServiceE.Entity
{
    public class Contexto : DbContext
    {


        public DbSet<Produt> Produtos { get; set; }


    }
}