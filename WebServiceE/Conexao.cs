using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServiceE
{

        public class Conexao
        {
            private static readonly Conexao instanciaAccess = new Conexao();

            private Conexao() { }

            public static Conexao getInstancia()
            {
                return instanciaAccess;
            }



            private static string GetCaminhoSql
            {
                get
                {

#pragma warning disable CS0618 // Type or member is obsolete
                    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBSql"];
#pragma warning restore CS0618 // Type or member is obsolete

                    return conn;
                }
            }



            public SqlConnection getConexaoSql()
            {
                return new SqlConnection(GetCaminhoSql);
            }
        }
    }
