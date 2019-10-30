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

        private List<Compra> compras;


        private List<Produt> estoque = new List<Produt>();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public xml ObterProdutoPorMarca(string marca_produto)
        {
            List<Entity.Produto> produtos = DAL.Produto.Instance.ListarProdutos();

            //Filtrando apenas produtos da marca escolhida
            var result = from f in produtos select f;
            if (marca_produto != "todas")
            {
                result = from f in produtos
                         where f.marca_func.Equals(marca_produto)
                         select f;
            }



            //Popular a Classe xml
            xml dadosXML = new xml(result.ToList());
            //Retornar o xml

            return dadosXML;
        }


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
    }
}
