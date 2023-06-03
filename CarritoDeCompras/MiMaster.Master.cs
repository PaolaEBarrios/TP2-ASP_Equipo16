using dominio;
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
            //ARREGLAR QUE AL AGREGAR LA PRIMERA VEZ NO AGREGA ARRIBA UNO.. PORQUE
            //PRIMERO CARGA LISTAR DE DEFAUL
            //LUEGO CARGA LA MASTER
            //Y POR ULTIMO EL CLICK BOTON

            Sesion sesion = new Sesion();

            int valor = sesion.CantSession();



            if ( valor == 0 )
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