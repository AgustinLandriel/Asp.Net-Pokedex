using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace controlador
{
    public class TraineeNegocio
    {
        public int CrearUser(Trainee user,bool admin = false)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setSP("insertarUsuario");
                datos.setVariables("@email", user.Email);
                datos.setVariables("@pass", user.Pass);

                return datos.ejecutarAccionScalar(); //Me devuelve el ID del user ingresado

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }

}
