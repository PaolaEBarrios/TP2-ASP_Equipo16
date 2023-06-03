using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;
namespace CarritoDeCompras
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            Sesion sesion=new Sesion();

                RepCarrito.DataSource = sesion.ListadeCarrito();
                RepCarrito.DataBind(); 

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Sesion sesion = new Sesion();
            CarritoNegocio negocio = new CarritoNegocio();

            string valor = ((Button)sender).CommandArgument;
            sesion.EliminarId(int.Parse(valor));
            //RepCarrito.DataSource = sesion.ListadeCarrito();
            //RepCarrito.DataBind();

            sesion.ArticuloASession(int.Parse(valor));



        }
    }
}