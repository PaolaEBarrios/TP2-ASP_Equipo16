using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;
using System.Drawing.Imaging;

namespace CarritoDeCompras
{
    public partial class Carrito : System.Web.UI.Page
    {
        
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            Sesion sesion = new Sesion();

            RepCarrito.DataSource = sesion.ListadeCarrito();
            RepCarrito.DataBind();

            float total = 0;

            foreach (var item in sesion.ListadeCarrito())
            {
                total += item.precio;
            }

            lblTotal.Text = total.ToString();
            
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Sesion sesion = new Sesion();
            CarritoNegocio negocio = new CarritoNegocio();

            string valor = ((Button)sender).CommandArgument;
            sesion.EliminarId(int.Parse(valor));
            //RepCarrito.DataSource = sesion.ListadeCarrito();
            //RepCarrito.DataBind();
            

            sesion.ArticuloEliminarEnSession(int.Parse(valor));


        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            //Label lbl = (Label)RepCarrito.FindControl("lblCantidad");
            //int total = int.Parse(lbl.Text);

             //total += 1;

            //lbl.Text = total.ToString();
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            //int total = int.Parse(lblCantidad.Text);

            
            //if (int.Parse(lblCantidad.Text) < 0)
            //{
               // total -= 1;

               // lblCantidad.Text = total.ToString();
           // }
            
        }
    }
}