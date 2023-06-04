using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoDeCompras
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Sesion sesion = new Sesion();
            int valor = sesion.CantSession();

            if (valor == 0)
            {
                lblContador.Text = "vacio";
            }
            else
            {
                lblContador.Text = valor.ToString();
            }
        }
    }
}