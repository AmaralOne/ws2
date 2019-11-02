using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServiceE.BLL
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

        public Entity.Pedido preencherObjeto(SqlDataReader dados)
        {
            Entity.Pedido obj = new Entity.Pedido();

            obj.id = int.Parse(dados["id"].ToString());
            obj.valor = float.Parse(dados["valor"].ToString());
            obj.status = dados["status"].ToString();

            obj.itens = DAL.Item.Instance.Listar(obj.id);

            
           
            return obj;
        }


        public string InserirPedido(Entity.Pedido pedido)
        {
            try
            {

                return DAL.Pedido.Instance.adiconarPedido(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }



        public string DeletarPedido(int id)
        {
            try
            {

                return DAL.Pedido.Instance.deletarPedido(id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }

        public List<Entity.Pedido> BuscarPedido(int id)
        {
            try
            {

                return DAL.Pedido.Instance.buscaPedido(id);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }

        public string AlterarPedido(Entity.Pedido pedido)
        {
            try
            {

                return DAL.Pedido.Instance.alterarPedido(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }

        public List<Entity.Pedido> ListarTodosPedidos()
        {
            try
            {

                return DAL.Pedido.Instance.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }
    }
}