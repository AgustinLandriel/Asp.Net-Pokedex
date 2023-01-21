using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace controlador
{
   public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("Select id,tipoUsuario from Usuario WHERE usuario = @user and pass = @pass");
                datos.setVariables("@user", usuario.User);
                datos.setVariables("@pass", usuario.Pass);

                datos.abrirConexion();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.TipoUsuario = (int)(datos.Lector["tipoUsuario"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;

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
