using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebServiceE.DAL
{
    public class Item
    {
        private static Item _instance;

        public static Item Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Item();

                return _instance;
            }
        }


        public string adiconarItem(Entity.Item item)
        {
            string retorno = "0";


            string valorPonto = item.valor.ToString().Replace(',', '.');
            string sql = "Insert into Item (Id,IdProduto,IdPedido,valor,quantidade) " +
               $"VALUES ('{item.id}','{item.idProduto}','{item.idPedido}','{valorPonto}','{item.qtd}');";


            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(sql, sqlConn);


                if(cmd.ExecuteNonQuery() == 1)
                {
                    retorno = item.id.ToString();
                }

                sqlConn.Close();
            }

            return retorno;
        }


        internal string alterarItem(Entity.Item item)
        {
            string retorno = "0";
            string valorPonto = item.valor.ToString().Replace(',', '.');
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Item SET ");

            sb.Append("IdProduto = '" + item.idProduto + "',");
            sb.Append("valor = '" + valorPonto + "',");
            sb.Append("quantidade = '" + item.qtd + "'");


            sb.Append($"WHERE Id = '{item.id}' and IdPedido = '{item.idPedido}'");

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConn);

                retorno = cmd.ExecuteNonQuery().ToString();


                sqlConn.Close();
            }

            return retorno;
        }

        internal int UltimoId()
        {
            int retorno = 0;

            string sql = "select top 1 Id from Item order by Id desc";

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();


                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader dadosProduto = cmd.ExecuteReader();

                if (dadosProduto.Read())
                {
                    retorno = int.Parse(dadosProduto["id"].ToString());
                }

                sqlConn.Close();
            }

            return retorno;
        }

        internal float ValorTotalItens(int idPedido)
        {
            float retorno = 0;

            string sql = "select sum(valor) as Total from Item where IdPedido ="+ idPedido+ " group by valor";

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();


                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader dadosProduto = cmd.ExecuteReader();

                if (dadosProduto.Read())
                {
                    retorno = float.Parse(dadosProduto["Total"].ToString());
                }

                sqlConn.Close();
            }

            return retorno;
        }

        internal string deletarItem(int id, int idPedido)
        {
            string retorno = "0";
            StringBuilder sb = new StringBuilder();
            string sql = $"delete from Item where Id = '{id}' and IdPedido = '{idPedido}'";

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(sql, sqlConn);


                if (cmd.ExecuteNonQuery() > 0)
                {

                    retorno = "1";

                }


                sqlConn.Close();
            }

            return retorno;
        }

        internal List<Entity.Item> buscaItem(int id, int idPedido)
        {
            List<Entity.Item> lista = new List<Entity.Item>();

            string sql = "select * from Item where Id = " + id + " and IdPedido = "+ idPedido;

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();


                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader dadosProduto = cmd.ExecuteReader();

                while (dadosProduto.Read())
                {
                    lista.Add(BLL.Item.Instance.preencherObjeto(dadosProduto));
                }

                sqlConn.Close();
            }

            return lista;
        }

        internal List<Entity.Item> Listar(int idPedido)
        {
            List<Entity.Item> lista = new List<Entity.Item>();

            string sql = "select * from Item where IdPedido = "+ idPedido;

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();


                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader dadosProduto = cmd.ExecuteReader();

                while (dadosProduto.Read())
                {
                    lista.Add(BLL.Item.Instance.preencherObjeto(dadosProduto));
                }

                sqlConn.Close();
            }

            return lista;
        }
    }
}