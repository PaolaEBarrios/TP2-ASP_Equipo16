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

        public void EliminarId(int id)
        {
            List<int> lista = ListadeSesion();
            lista.Remove(id);
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





        public List<Carrito> ListadeCarrito()
        {


            if (listaCarrito == null)
            {
                listaCarrito = new List<Carrito>();
                HttpContext.Current.Session["CarroCompra"] = listaCarrito;
            }

            return listaCarrito;
        }


        
            
      

        public void ArticuloASession(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            List<Carrito> list = ListadeCarrito();
            List <Articulo> listaArticulo= new List<Articulo>();
            Carrito carrito=new Carrito();


            try
            {

                
                listaArticulo = negocio.listarArticuloXid(id.ToString());


                foreach (Articulo item in listaArticulo)
                {
                    carrito.Id = item.Id;
                    carrito.precio= (float)item.precio;
                    carrito.nombre = item.nombre;
                    carrito.marca = item.Marca.marca;
                 
                }

                list.Add(carrito);

                HttpContext.Current.Session["CarroCompra"] = list;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ArticuloEliminarEnSession(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            List<Carrito> list = ListadeCarrito();
            List<Articulo> listaArticulo = new List<Articulo>();
            Carrito carrito = new Carrito();


            try
            {


                listaArticulo = negocio.listarArticuloXid(id.ToString());


                foreach (Articulo item in listaArticulo)
                {
                    carrito.Id = item.Id;
                    carrito.precio = (float)item.precio;
                    carrito.nombre = item.nombre;
                    carrito.marca = item.Marca.marca;

                }

                list.Remove(carrito);

                HttpContext.Current.Session["CarroCompra"] = list;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
