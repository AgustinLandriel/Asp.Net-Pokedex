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
        public int CrearUser(Trainee user)
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
    public bool Login(Trainee user)
    {
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setQuery("Select id,email,pass,admin from  USERS where email = @email and pass=@pass");
            datos.setVariables("@email", user.Email);
            datos.setVariables("@pass", user.Pass);

            datos.abrirConexion();

            if (datos.Lector.Read())
            {
                user.Id = (int)datos.Lector["id"];
                user.Admin = (bool)datos.Lector["admin"];
                return true;
            }

            return false;

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
