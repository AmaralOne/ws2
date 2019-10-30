using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebServiceE.Entity;

namespace WebServiceE.DAL
{
    public class Produto
    {

        private string idt_func = "0";
        private string nome_func = "teste1";
        private string descricao_func = "teste2";
        private string categoria_func = "1";
        private string modelo_func = "teste@gmail.com";
        private string marca_func = "teste";
        private string valor_func = "2";
        private string quantidade_func = "3";


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

        public string adiconarProduto(Produt p)
        {
            string retorno = "0";

            string sql = "Insert into Produtos (Id,nome,descricao,categoria,modelo,marca,valor,quantidade,inativo) " +
               $"VALUES ({p.id},'{p.nome}','{p.descricao}','{p.categoria}','{p.modelo}','{p.marca}','{p.valor}','{p.quantidade}','0');";

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                SqlCommand cmd = new SqlCommand(sql, sqlConn);



                retorno = cmd.ExecuteNonQuery().ToString();


                sqlConn.Close();
            }

            

            return retorno;
        }

        internal List<Produt> Listar()
        {
            List<Produt> lista = new List<Produt>();

            string sql = "SELECT * FROM Produtos";

            using (SqlConnection sqlConn = Conexao.getInstancia().getConexaoSql())
            {
                sqlConn.Open();

                //OdbcDataReader dadosProduto = new OdbcCommand(sql, conexaoAccess).ExecuteReader();

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader dadosProduto = cmd.ExecuteReader();

                while (dadosProduto.Read())
                {
                    lista.Add(BLL.Produto.Instance.preencherObjeto(dadosProduto));
                }

                sqlConn.Close();
            }

            return lista;
        }

        public List<Entity.Produto> ListarProdutos()
        {
            //Criando lista de produtos
            List<Entity.Produto> produtos = new List<Entity.Produto>();



            Entity.Produto produto;
            //Obtendo todos os produtos
            DataTable dteProd = DAL.Produto.Instance.DadosProduto();
            //Populando a lista de produtos
            foreach (DataRow row in dteProd.Rows)
            {
                produto = new Entity.Produto();
                produto.idt_func = row[idt_func].ToString();
                produto.nome_func = row[nome_func].ToString();
                produto.descricao_func = row[descricao_func].ToString();
                produto.categoria_func = row[categoria_func].ToString();
                produto.modelo_func = row[modelo_func].ToString();
                produto.marca_func = row[marca_func].ToString();
                produto.valor_func = row[valor_func].ToString();
                produto.quantidade_func = row[quantidade_func].ToString();
                produtos.Add(produto);
            }

            return produtos;
        }
        //Criando dados fictícios de produtos
        public DataTable DadosProduto()
        {
            DataTable dadosProdutos = new DataTable();
            dadosProdutos.Columns.Add(idt_func);
            dadosProdutos.Columns.Add(nome_func);
            dadosProdutos.Columns.Add(descricao_func);
            dadosProdutos.Columns.Add(categoria_func);
            dadosProdutos.Columns.Add(modelo_func);
            dadosProdutos.Columns.Add(marca_func);
            dadosProdutos.Columns.Add(valor_func);
            dadosProdutos.Columns.Add(quantidade_func);
            //                     ID    Nome                     Descrição                                                                                  Categoria      Modelo                     Marca              Valor     QT                   
            dadosProdutos.Rows.Add("1", "Galaxy A20", "Smartphone 32 GB - Preto", "Celular", "SM - A205G", "Samsumg", "739", "4");
            dadosProdutos.Rows.Add("2", "Memória HyperX Fury", "8GB 2666MHz, DDR4 - Preto", "Memoria Ram", "HX426C16FB3 / 8", "HyperX", "232,82", "10");
            dadosProdutos.Rows.Add("3", "SSD Kingston A400", "SSD Kingston A400, 240GB, SATA, Leitura 500MB / s, Gravação 350MB / s - SA400S37 / 240G", "SSD", "SA400S37 / 240G", "Kingston", "205,76", "6");
            dadosProdutos.Rows.Add("4", "Asus Prime Gaming - BR", "As placas - mãe ASUS Prime Série B450", "Placa - Mãe", "Prime B450M Gaming / BR", "ASUS", "455,9", "2");
            dadosProdutos.Rows.Add("5", "Acer Aspire Nitro 5", "Intel Core i5 - 7300HQ 8GB 1TB NVIDIA GeForce GTX 1050 4GB GDDR5 15, 6", "Notbook", "AN515 - 51 - 55YB", "ACER", "3699,9", "1");
            dadosProdutos.Rows.Add("6", "Acer Aspire Nitro 3", "AMD Ryzen 3 2200U, 4GB, 1TB, Radeon Vega 3, Windows 10 Home, 15.6", "Notbook", "A315 - 41 - R790", "ACER", "2199,9", "2");
            dadosProdutos.Rows.Add("7", "Sharkoon", "HUB Sharkoon USB 3.0 4 Portas Tipo - C Alumínio BK", "Periferico", "HUB", "Sharkoon", "119,88", "4");
            dadosProdutos.Rows.Add("8", "DataTraveler", "Pen Drive Kingston DataTraveler USB 3.0 32GB", "Periferico", "DT100G3", "Kingston", "38,71", "20");
            dadosProdutos.Rows.Add("9", "Calculadora Vinik", "Calculadora Científica Vinik 10 + 2 Dígitos 240 Funções CC20 - 26096 Preta", "Eletronico", "26096", "Vinik", "18,71", "30");
            dadosProdutos.Rows.Add("10", "SSD WD", "SSD WD Green, 240GB, SATA, Leitura 545MB / s, Gravação 465MB / s", "SSD", "WDS240G2G0A", "Western Digital", "246,94", "7");



            return dadosProdutos;
        }
    }
}