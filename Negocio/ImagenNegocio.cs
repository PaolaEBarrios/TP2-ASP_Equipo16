using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listarImagenXidArticulo(string id)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select i.id as Id,i.ImagenUrl as url,i.IdArticulo as idarticulo from IMAGENES as i where i.IdArticulo = ";
                consulta += id;

                datos.setearQuery(consulta);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();

                    aux.id = (int)datos.Lector["Id"];
                    aux.idArticulo = (int)datos.Lector["idarticulo"];    
                
                    aux.url = (string)datos.Lector["url"];

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

