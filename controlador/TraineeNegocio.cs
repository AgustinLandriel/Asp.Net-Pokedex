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
            datos.setQuery("Select id,nombre,apellido,imagenPerfil,admin from  USERS where email = @email and pass=@pass");
            datos.setVariables("@email", user.Email);
            datos.setVariables("@pass", user.Pass);

            datos.abrirConexion();

            if (datos.Lector.Read())
            {
                user.Id = (int)datos.Lector["id"];
                if (!(datos.Lector["nombre"] is DBNull))
                    user.Nombre = (string)datos.Lector["nombre"];
                if (!(datos.Lector["apellido"] is DBNull))
                    user.Apellido = (string)datos.Lector["apellido"];
                user.Admin = (bool)datos.Lector["admin"];
                if(!(datos.Lector["imagenPerfil"] is DBNull)) //Si no es nulo, que lea la imagen
                   user.ImagenPerfil = (string)datos.Lector["imagenPerfil"];

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

        public void Actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("UPDATE USERS set nombre = @nombre, apellido = @apellido, imagenPerfil = @imagen WHERE id = @id");
                datos.setVariables("@imagen", user.ImagenPerfil);
                datos.setVariables("@id", user.Id);
                datos.setVariables("@nombre", user.Nombre);
                datos.setVariables("@apellido", user.Apellido);
                datos.commitConsulta();
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
    }

}
