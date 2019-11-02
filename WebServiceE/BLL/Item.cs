using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServiceE.BLL
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

        public Entity.Item preencherObjeto(SqlDataReader dados)
        {
            Entity.Item obj = new Entity.Item();

            obj.id = int.Parse(dados["Id"].ToString());
            obj.idPedido = int.Parse(dados["IdPedido"].ToString());
            obj.idProduto = int.Parse(dados["IdProduto"].ToString());
            obj.valor = float.Parse(dados["valor"].ToString());
            obj.qtd = int.Parse(dados["quantidade"].ToString());

            return obj;
        }


        public string InserirItem(Entity.Item item)
        {
            try
            {
                string retorno = "0";
                item.id = DAL.Item.Instance.UltimoId()+1;
                retorno = DAL.Item.Instance.adiconarItem(item);
                if(retorno == "1")
                {
                    float valorTotalPedido = DAL.Item.Instance.ValorTotalItens(item.idPedido);
                    var p = new Entity.Pedido();
                    p.id = item.idPedido;
                    p.valor = valorTotalPedido;
                    p.status = "0";
                    retorno = DAL.Pedido.Instance.alterarPedido(p);
                }


                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }


        public string DeletarItem(int id, int idPedido)
        {
            try
            {
                string retorno = "0";
                retorno =  DAL.Item.Instance.deletarItem(id, idPedido);
                if (retorno == "1")
                {
                    float valorTotalPedido = DAL.Item.Instance.ValorTotalItens(idPedido);
                    var p = new Entity.Pedido();
                    p.id = idPedido;
                    p.valor = valorTotalPedido;
                    p.status = "0";
                    retorno = DAL.Pedido.Instance.alterarPedido(p);
                }

                return retorno; 
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }

            
        }

        public string AlterarItem(Entity.Item item)
        {
            try
            {

                string retorno = "0";

                retorno = DAL.Item.Instance.alterarItem(item);
                if (retorno == "1")
                {
                    float valorTotalPedido = DAL.Item.Instance.ValorTotalItens(item.idPedido);
                    var p = new Entity.Pedido();
                    p.id = item.idPedido;
                    p.valor = valorTotalPedido;
                    p.status = "0";
                    retorno = DAL.Pedido.Instance.alterarPedido(p);
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }

        public List<Entity.Item> ListarTodosItens(int IdPedido)
        {
            try
            {

                return DAL.Item.Instance.Listar(IdPedido);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }

        public List<Entity.Item> Buscaritem(int id, int idPedido)
        {
            try
            {

                return DAL.Item.Instance.buscaItem(id, idPedido);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(ex.Message));
            }
        }
    }
}