using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()

        {
            conexion=new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security = True");
            //conexion = new SqlConnection("server=.\\SQLEXPRESS; Integrated Security = False; database = CATALOGO_P3_DB; uid = myUser; password = myPass");
            comando =new SqlCommand();


        }

        public void setearQuery(string consulta)
        {
            comando.CommandType=System.Data.CommandType.Text; ;
            comando.CommandText=consulta;
        }


        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        
        }

        public void setParameters(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
                conexion.Close();
            
            }
        }

    }
}
