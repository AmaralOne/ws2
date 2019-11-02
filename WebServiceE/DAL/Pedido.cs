using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebServiceE.DAL
{
    public class Pedido
    {
        private static Pedido _instance;

        public static Pedido Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Pedido();

                return _instance;
            }
        }

        public string adiconarPedido(Entity.Pedido p)
        {
            string retorno = "0";


            int id = 0;
            string valorPonto = p.valor.ToString().Replace(',', '.');
            string sql = "Insert into Pedido (valor,status,inativo) " +
               $"VALUES ('{valorPonto}','{p.status}','0'); SET @ID = SCOPE_IDENTITY();";


            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(sql, sqlConn);


                cmd.Parameters.AddWithValue("@ID", 0).Direction = ParameterDirection.Output;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    id = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                }



                sqlConn.Close();
            }

            retorno = id.ToString();



            return retorno;
        }

        internal string alterarPedido(Entity.Pedido p)
        {
            string retorno = "0";
            string valorPonto = p.valor.ToString().Replace(',', '.');
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Pedido SET ");

            sb.Append("valor = '" + valorPonto + "',");
            sb.Append("status = '" + p.status + "'");


            sb.Append("WHERE Id = " + p.id);

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConn);

                retorno = cmd.ExecuteNonQuery().ToString();


                sqlConn.Close();
            }

            return retorno;
        }

        internal List<Entity.Pedido> buscaPedido(int id)
        {
            List<Entity.Pedido> lista = new List<Entity.Pedido>();

            string sql = "select * from Pedido where inativo = '0' and Id = " + id + "";

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                //OdbcDataReader dadosProduto = new OdbcCommand(sql, conexaoAccess).ExecuteReader();

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader dadosProduto = cmd.ExecuteReader();

                while (dadosProduto.Read())
                {
                    lista.Add(BLL.Pedido.Instance.preencherObjeto(dadosProduto));
                }

                sqlConn.Close();
            }

            return lista;
        }

        internal string deletarPedido(int id)
        {
            string retorno = "0";
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Pedido SET ");

            sb.Append("inativo = '1'");


            sb.Append("WHERE Id = " + id);

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(sb.ToString(), sqlConn);

                retorno = cmd.ExecuteNonQuery().ToString();


                sqlConn.Close();
            }

            return retorno;
        }

        internal List<Entity.Pedido> Listar()
        {
            List<Entity.Pedido> lista = new List<Entity.Pedido>();

            string sql = "select * from Pedido where inativo = '0'";

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                //OdbcDataReader dadosProduto = new OdbcCommand(sql, conexaoAccess).ExecuteReader();

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader dadosProduto = cmd.ExecuteReader();

                while (dadosProduto.Read())
                {
                    lista.Add(BLL.Pedido.Instance.preencherObjeto(dadosProduto));
                }

                sqlConn.Close();
            }

            return lista;
        }
    }
}