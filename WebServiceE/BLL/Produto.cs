using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebServiceE.Entity;

namespace WebServiceE.BLL
{
    public class Produto
    {
        private static Produto _instance;

        public static Produto Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Produto();

                return _instance;
            }
        }

        public string InserirProduto(Produt produto)
        {
            try
            {

                return DAL.Produto.Instance.adiconarProduto(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }

        public Produt preencherObjeto(SqlDataReader dados)
        {
            Produt obj = new Produt();

            obj.id = dados["id"].ToString();
            obj.nome = dados["nome"].ToString();
            obj.marca = dados["marca"].ToString();
            obj.modelo = dados["modelo"].ToString();
            obj.quantidade = dados["quantidade"].ToString();
            obj.valor = dados["valor"].ToString();
            obj.categoria = dados["categoria"].ToString();
            obj.descricao = dados["descricao"].ToString();

            return obj;
        }

        public List<Produt> ListarTodosProduto()
        {
            try
            {

                return DAL.Produto.Instance.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }
    }
}