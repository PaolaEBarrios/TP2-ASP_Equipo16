using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearQuery("Select a.Id as Id, a.Codigo as Codigo,a.Nombre as Nombre,a.Descripcion as Descripcion,c.Descripcion AS Categoria,m.Descripcion AS Marca,i.ImagenUrl AS UrlImagen, a.Precio as Precio from ARTICULOS as a left join IMAGENEs as i on i.IdArticulo = a.Id left join marcas as m on m.Id = a.IdMarca left join CATEGORIAS as c on c.Id = a.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();


                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.codigoArticulo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.descripcion = (string)datos.Lector["Descripcion"];


                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.categoria = (string)datos.Lector["Categoria"];
                    else
                        aux.Categoria.categoria = "Sin categoria";

                    aux.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.marca = (string)datos.Lector["Marca"];
                    else
                        aux.Marca.marca = "Sin marca";


                    aux.imagen = new Imagen();
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.imagen.url = (string)datos.Lector["UrlImagen"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.precio = (decimal)datos.Lector["Precio"];
                    
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
            
               
        }

        public void AgregarArticulo (Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)values('" + articulo.codigoArticulo + "','" + articulo.nombre + "','" + articulo.descripcion + "'," + articulo.Marca.idMarca + "," + articulo.Categoria.idCategoria + "," + articulo.precio + ") Insert into Imagenes (idArticulo,imagenurl) values (" + articulo.Id + ",'" + articulo.imagen.url + "')"); 
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ModificarArticulo(Articulo modificar)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                //Datos.setearQuery("update ARTICULOS set Codigo = '"+ modificar.codigoArticulo +"', Nombre = '"+ modificar.nombre +"', Descripcion = '"+ modificar.descripcion +"', IdMarca = "+ modificar.Marca +", IdCategoria = "+ modificar.Categoria +", Precio = "+ modificar.precio +" Where Id = "+ modificar.Id +"");
                Datos.setearQuery("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria,  Precio = @precio  Where Id = @id");
                Datos.setParameters("@codigo", modificar.codigoArticulo);
                Datos.setParameters("@nombre", modificar.nombre);
                Datos.setParameters("@descripcion", modificar.descripcion);
                Datos.setParameters("@IdMarca", modificar.Marca.idMarca);
                Datos.setParameters("@IdCategoria", modificar.Categoria.idCategoria);
                Datos.setParameters("@precio", modificar.precio);
                Datos.setParameters("@id", modificar.Id);
                Datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        public void EliminarArticulo(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearQuery("delete from ARTICULOS where Id = @id");
                datos.setParameters("@id", id);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int TraerUltimoId()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                int cont = 0;
                datos.setearQuery("select id from ARTICULOS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    cont++;
                }

                return cont+1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SPlistarArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                    {
                        aux.codigoArticulo = (string)datos.Lector["Codigo"];
                    }

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.marca = (string)datos.Lector["Marca"];
                    else
                        aux.Marca.marca = "Sin marca";

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.categoria = (string)datos.Lector["Categoria"];
                    else
                        aux.Categoria.categoria = "Sin categoria";

                    //if(!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ImagenUrl"))))
                    //  aux.UrlImagen = (string)datos.Lector.GetString(5);

                    aux.imagen = new Imagen();
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.imagen.url = (string)datos.Lector["UrlImagen"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.precio = (decimal)datos.Lector["Precio"];


                    //datos.cerrarConexion();
                    lista.Add(aux);

                }


                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Articulo>listarArticuloXid(string id)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select a.Codigo as Codigo,a.Descripcion as Descripcion,c.Descripcion as Categoria,m.Descripcion as Marca,a.Nombre as Nombre,a.Precio as Precio from ARTICULOS as a left join MARCAS as m on m.Id = a.IdMarca left join CATEGORIAS as c on c.Id = a.IdCategoria where a.id =  ";
                consulta += id;
                
                datos.setearQuery(consulta);
                datos.ejecutarLectura();

               
                if(datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.codigoArticulo = (string)datos.Lector["Codigo"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.descripcion = (string)datos.Lector["Descripcion"];
                    
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.categoria = (string)datos.Lector["Categoria"];
                    else
                        aux.Categoria.categoria = "Sin categoria";
                    

                    aux.Marca = new Marca();

                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.marca = (string)datos.Lector["Marca"];
                    else
                        aux.Marca.marca = "Sin marca";

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Precio"]is DBNull))
                        aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);

                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

     }
}
