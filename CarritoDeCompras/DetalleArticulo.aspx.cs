using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace CarritoDeCompras
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> articuloList = new List<Articulo>();
            List<Imagen> imagenList = new List<Imagen>();

            try
            {
                string id = Request.QueryString["id"];

                ArticuloNegocio negocio = new ArticuloNegocio();
                ImagenNegocio negocioImagen = new ImagenNegocio();
                
                articuloList = negocio.listarArticuloXid(id);
                imagenList=negocioImagen.listarImagenXidArticulo(id);

                dgvDetalleArticulo.DataSource= articuloList;
                
                repImagen.DataSource= imagenList;
                repImagen.DataBind();
                

                
                DataBind();
                LblArticulo.Text = id;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}