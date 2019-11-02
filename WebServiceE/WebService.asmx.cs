using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;


using WebServiceE.Entity;

namespace WebServiceE
{

    /// <summary>
    /// Descrição resumida de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

       


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string addProdut(string json)
        {
            string mensagem = null;

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Produt p = js.Deserialize<Produt>(json);
                
                string retorno = BLL.Produto.Instance.InserirProduto(p);

                

                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string addPedido(string json)
        {
            string mensagem = null;

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Pedido p = js.Deserialize<Pedido>(json);

                string retorno = BLL.Pedido.Instance.InserirPedido(p);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string addItem(string json)
        {
            string mensagem = null;

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Entity.Item item = js.Deserialize<Entity.Item>(json);

                string retorno = BLL.Item.Instance.InserirItem(item);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string alterarProdut(string json)
        {
            string mensagem = null;

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Produt p = js.Deserialize<Produt>(json);

                string retorno = BLL.Produto.Instance.AlterarProduto(p);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string alterarItem(string json)
        {
            string mensagem = null;

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Entity.Item item = js.Deserialize<Entity.Item>(json);

                string retorno = BLL.Item.Instance.AlterarItem(item);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string alterarPedido(string json)
        {
            string mensagem = null;

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                Entity.Pedido p = js.Deserialize<Entity.Pedido>(json);

                string retorno = BLL.Pedido.Instance.AlterarPedido(p);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string deletarProdut(int id)
        {
            string mensagem = null;

            try
            {



                string retorno = BLL.Produto.Instance.DeletarProduto(id);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string deletarItem(int id, int idPedido)
        {
            string mensagem = null;

            try
            {



                string retorno = BLL.Item.Instance.DeletarItem(id, idPedido);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string deletarPedido(int id)
        {
            string mensagem = null;

            try
            {



                string retorno = BLL.Pedido.Instance.DeletarPedido(id);



                return retorno;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string listProdut()
        {
            string mensagem = null;

            try
            {


                List<Produt> retorno = BLL.Produto.Instance.ListarTodosProduto();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue;
                mensagem = jss.Serialize(retorno);



                return mensagem;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string listPedido()
        {
            string mensagem = null;

            try
            {


                List<Entity.Pedido> retorno = BLL.Pedido.Instance.ListarTodosPedidos();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue;
                mensagem = jss.Serialize(retorno);



                return mensagem;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string listItem(int idPedido)
        {
            string mensagem = null;

            try
            {


                List<Entity.Item> retorno = BLL.Item.Instance.ListarTodosItens(idPedido);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue;
                mensagem = jss.Serialize(retorno);



                return mensagem;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string buscaProdut(string nome)
        {
            string mensagem = null;

            try
            {


                List<Produt> retorno = BLL.Produto.Instance.BuscarProduto(nome);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue;
                mensagem = jss.Serialize(retorno);



                return mensagem;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string buscaProdutoPorId(int id)
        {
            string mensagem = null;

            try
            {


                List<Produt> retorno = BLL.Produto.Instance.BuscarProdutoPorId(id);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue;
                mensagem = jss.Serialize(retorno);



                return mensagem;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string buscaItem(int id, int idPedido)
        {
            string mensagem = null;

            try
            {


                List<Entity.Item> retorno = BLL.Item.Instance.Buscaritem(id,idPedido);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue;
                mensagem = jss.Serialize(retorno);



                return mensagem;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public string buscaPedido(int id)
        {
            string mensagem = null;

            try
            {


                List<Entity.Pedido> retorno = BLL.Pedido.Instance.BuscarPedido(id);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue;
                mensagem = jss.Serialize(retorno);



                return mensagem;

            }
            catch (Exception e)
            {
                mensagem = "ErrorServer.: " + e.Message;
            }

            return mensagem;



        }
    }
}
