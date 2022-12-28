using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace controlador
{
   public class ElementoNegocio
    {

        public List<Elemento> getElementos()
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos();

            try
            {   datos.setQuery("SELECT id,descripcion FROM ELEMENTOS ");
                datos.abrirConexion();

                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.IdElemento = (int)datos.Lector["id"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];

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
    }
}
