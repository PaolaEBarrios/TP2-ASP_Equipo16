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
    public partial class Default : System.Web.UI.Page
    {

        
        public List<Articulo> ListaArticulo { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            AccesoDatos datos = new AccesoDatos();
            datos.setearQuery("create PROCEDURE SPlistarArticulo\r\nAS\r\nSELECT min(I.IMAGENURL)as UrlImagen, A.ID as Id,A.CODIGO as Codigo,A.NOMBRE as Nombre,A.Descripcion as Descripcion, C.Descripcion as Categoria, M.Descripcion as Marca,A.Precio as Precio\r\nfrom ARTICULOS as a\r\nleft join\r\nIMAGENES as i\r\non i.IdArticulo=a.id\r\nleft join MARCAS as m\r\non m.id=a.IdMarca\r\nleft join CATEGORIAS as c\r\non c.id=a.IdCategoria\r\ngroup by i.IdArticulo,a.Nombre,a.codigo,a.Descripcion,a.precio,a.id,c.Descripcion,m.Descripcion ");
            datos.ejecutarLectura();
            datos.cerrarConexion();
            ArticuloNegocio negocio = new ArticuloNegocio();
            
            ListaArticulo = negocio.listarConSP();



        

            if(!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
                
            }


            datos.setearQuery("drop PROCEDURE SPlistarArticulo");
            datos.ejecutarLectura();
            datos.cerrarConexion();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Sesion  sesion = new Sesion();
            CarritoNegocio negocio = new CarritoNegocio();

            string valor = ((Button)sender).CommandArgument;
            sesion.AgregarId(int.Parse(valor));
            // negocio.AgregarAlCarrito(int.Parse(valor));

            sesion.ArticuloASession(int.Parse(valor));
            
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista= (List<Articulo>)Session["Lista Articulos"];
        }
    } 
}