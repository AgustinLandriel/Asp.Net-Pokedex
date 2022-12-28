using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace dominio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            //Hago la conexion a la BD cuando se instancia la clase.
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true;");
            comando = new SqlCommand();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void setQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        public void commitConsulta()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setVariables(string var ,object valor)
        {
            comando.Parameters.AddWithValue(var, valor);
        }

        public void abrirConexion()
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

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }
    }
}
