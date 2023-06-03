using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using dominio;


namespace Negocio
{
    public class Sesion
    {
        List<int> lista = (List<int>)HttpContext.Current.Session["id"];

        List<Carrito> listaCarrito = (List<Carrito>)HttpContext.Current.Session["CarroCompra"];

        public  List<int> ListadeSesion()
        {
            

            if (lista == null)
            {
                lista = new List<int>();
                HttpContext.Current.Session["id"] = lista;
            }

            return lista;
        }


        public void AgregarId(int id)
        {
            List<int> lista = ListadeSesion();
            lista.Add(id);
            HttpContext.Current.Session["id"] = lista;
        }


        public int CantSession()
        {
            List<int> lista = ListadeSesion();
            if(lista == null)
                return 0;
            else
                return lista.Count;
        }



        public void ArticuloASession(int id)
        {

            ArticuloNegocio negocio = new ArticuloNegocio(); 

            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
