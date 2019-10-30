using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class ProdutoDAO
    {

        public bool addProduto(Produto produto)
        {
            Contexto context = new Contexto();
            // adicionando os registros e salvando
            context.Produtos.Add(produto);
            context.SaveChanges();

            return true;
        }
    }
}
