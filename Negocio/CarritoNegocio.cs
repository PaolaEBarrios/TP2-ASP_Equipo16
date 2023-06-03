using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class CarritoNegocio
    {
        public List<Carrito> listaCarrito = new List<Carrito>();

        public List<Carrito> listar()
        {
            

            return listaCarrito;
        }




        public void AgregarAlCarrito(int id)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            AccesoDatos accesoDatos = new AccesoDatos();
            Carrito carrito = new Carrito();

            try
            {
                listaCarrito = CargarLista(id);




            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Carrito> CargarLista(int id)
        {
            List<Carrito> lista = new List<Carrito>();

            try
            {



                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
    }
}
