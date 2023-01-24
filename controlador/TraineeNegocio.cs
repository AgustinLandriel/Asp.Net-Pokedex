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
                datos.setQuery("Select id,nombre,email,pass,apellido,imagenPerfil,fechaNacimiento,admin from  USERS where email = @email and pass=@pass");
                datos.setVariables("@email", user.Email);
                datos.setVariables("@pass", user.Pass);

                datos.abrirConexion();

                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["id"];
                    user.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["imagenPerfil"] is DBNull)) //Si no es nulo, que lea la imagen
                        user.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
                    if (!(datos.Lector["fechaNacimiento"] is DBNull))
                        user.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());

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
                datos.setQuery("UPDATE USERS set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fechaNacimiento, imagenPerfil = @imagen WHERE id = @id");
                //datos.setVariables("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value );
                datos.setVariables("@imagen", (object)user.ImagenPerfil ?? DBNull.Value); // ?? -> NULL COALESING
                datos.setVariables("@id", user.Id);
                datos.setVariables("@nombre", user.Nombre);
                datos.setVariables("@apellido", user.Apellido);
                datos.setVariables("@fechaNacimiento", user.FechaNacimiento);
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
