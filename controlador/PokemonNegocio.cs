using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        List<Pokemon> listaPokemon = new List<Pokemon>();

        public List<Pokemon> getPokemon(string id = "")
        {
            try
            {
                string consulta = @"SELECT p.id,numero,nombre,p.descripcion,urlImagen,e.descripcion as Tipo, d.descripcion as Debilidad,idTipo,IdDebilidad 
                                 from POKEMONS as p
                                 inner join ELEMENTOS e 
                                 on ( p.IdTipo = e.Id)
                                 inner join elementos d 
                                 on(p.IdDebilidad = d.Id) 
                                 WHERE p.activo = 1 ";
                datos.setQuery(consulta);
                if(id != null)
                {
                    consulta += "and p.id = " + id;
                }

                datos.abrirConexion();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["id"];
                    aux.Numero = (int)datos.Lector["numero"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];

                    //Si los datos son nulos no los leo
                    if (!(datos.Lector["urlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["urlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.IdElemento = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.IdElemento = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    listaPokemon.Add(aux);
                }

                return listaPokemon;
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

        public List<Pokemon> listarConSP()
        {
            List<Pokemon> listaFiltrada = new List<Pokemon>();

            try
            {
                /* string consulta = @"SELECT p.id,numero,nombre,p.descripcion,urlImagen,e.descripcion as Tipo, d.descripcion as Debilidad,idTipo,IdDebilidad 
                                  from POKEMONS as p
                                  inner join ELEMENTOS e 
                                  on ( p.IdTipo = e.Id)
                                  inner join elementos d 
                                  on(p.IdDebilidad = d.Id) 
                                  WHERE p.activo = 1";*/

                datos.setSP("storedListar");
                datos.abrirConexion();


                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["id"];
                    aux.Numero = (int)datos.Lector["numero"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];

                    //Si los datos son nulos no los leo
                    if (!(datos.Lector["urlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["urlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.IdElemento = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.IdElemento = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    aux.Activo = (bool)datos.Lector["activo"];
                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;
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

        public void agregarPokemon(Pokemon pokemon)
        {

            try
            {
                datos.setQuery("INSERT INTO POKEMONS (numero,nombre,descripcion, UrlImagen,idTipo,IdDebilidad) values (" + pokemon.Numero + ",'" + pokemon.Nombre + "','" + pokemon.Descripcion + "','" + pokemon.UrlImagen + "',@IdTipo,@IdDebilidad)");
                datos.setVariables("@IdTipo", pokemon.Tipo.IdElemento);
                datos.setVariables("@IdDebilidad", pokemon.Debilidad.IdElemento);
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

        public void agregarPokemonSP(Pokemon pokemon)
        {

            try
            {
                //Llamo a la query de sp
                datos.setSP("sp_altaPokemon");
                //Seteo Parametros
                datos.setVariables("@numero", pokemon.Numero);
                datos.setVariables("@nombre", pokemon.Nombre);
                datos.setVariables("@descripcion", pokemon.Descripcion);
                datos.setVariables("@urlimagen", pokemon.UrlImagen);
                datos.setVariables("@IdTipo", pokemon.Tipo.IdElemento);
                datos.setVariables("@IdDebilidad", pokemon.Debilidad.IdElemento);
               // datos.setVariables("@IdEvolucion", null);
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
        public void modificarPokemon(Pokemon pokemon)
        {
            try
            {
                datos.setQuery("UPDATE POKEMONS set numero = @numero,nombre=@nombre,descripcion = @descripcion,urlImagen = @urlimagen,IdTipo = @IdTipo,IdDebilidad=@IdDebilidad WHERE id = @id");
                datos.setVariables("@numero", pokemon.Numero);
                datos.setVariables("@nombre", pokemon.Nombre);
                datos.setVariables("@descripcion", pokemon.Descripcion);
                datos.setVariables("@urlimagen", pokemon.UrlImagen);
                datos.setVariables("@IdTipo", pokemon.Tipo.IdElemento);
                datos.setVariables("@IdDebilidad", pokemon.Debilidad.IdElemento);
                datos.setVariables("@Id", pokemon.Id);
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

        public void modificarPokemonSP(Pokemon pokemon)
        {
            try
            {
                //datos.setQuery("UPDATE POKEMONS set numero = @numero,nombre=@nombre,descripcion = @descripcion,urlImagen = @urlimagen,IdTipo = @IdTipo,IdDebilidad=@IdDebilidad WHERE id = @id");
                datos.setSP("SP_MODIFICAR");
                datos.setVariables("@numero", pokemon.Numero);
                datos.setVariables("@nombre", pokemon.Nombre);
                datos.setVariables("@descripcion", pokemon.Descripcion);
                datos.setVariables("@urlimagen", pokemon.UrlImagen);
                datos.setVariables("@IdTipo", pokemon.Tipo.IdElemento);
                datos.setVariables("@IdDebilidad", pokemon.Debilidad.IdElemento);
                datos.setVariables("@Id", pokemon.Id);
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

        public void eliminarFisicamente(int id)
        {
            try
            {
                datos.setQuery("DELETE FROM POKEMONS WHERE id = @id");
                datos.setVariables("@id", id);
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

        public void eliminarFisicamenteSP ( int id)
        {
            try
            {
                // datos.setQuery("DELETE FROM POKEMONS WHERE id = @id");
                datos.setSP("SP_ELIMINAR");
                datos.setVariables("@id", id);
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
        public void eliminarLogico(int id)
        {
            try
            {
                datos.setQuery("UPDATE POKEMONS set activo = 0 WHERE id = @id");
                datos.setVariables("@id", id);
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

        public void eliminarLogicoSP (int id, bool activo = false)
        {
            try
            {
                datos.setSP("SP_EliminarLogico");
                datos.setVariables("@id", id);
                datos.setVariables("@activo", activo);
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

        public List<Pokemon> filtroAvanzado(string campo, string criterio, string filtro,string estado)
        {
            List<Pokemon> listaFiltrada = new List<Pokemon>();

            try
            {
                string consulta = @"SELECT p.id,numero,nombre,p.descripcion,urlImagen,e.descripcion as Tipo, d.descripcion as Debilidad,idTipo,IdDebilidad,p.activo 
                                 from POKEMONS as p
                                 inner join ELEMENTOS e 
                                 on ( p.IdTipo = e.Id)
                                 inner join elementos d 
                                 on(p.IdDebilidad = d.Id) 
                                 WHERE ";


                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero <" + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if(campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "nombre like '" + filtro + "%'"; // 'filtro%'
                            break;
                        case "Termina con":
                            consulta += "nombre like '%" + filtro + "'"; // '%filtro'
                            break;
                        default:
                            consulta += "nombre like '%" + filtro + "%'"; // '%filtro%'
                            break;
                    }
                } else
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "e.descripcion like '" + filtro + "%'"; // 'filtro%'
                            break;
                        case "Termina con":
                            consulta += "e.descripcion like '%" + filtro + "'"; // '%filtro'
                            break;
                        default:
                            consulta += "e.descripcion '%" + filtro + "%'"; // '%filtro%'
                            break;
                    }
                }

                //Compruebo el estado de activo

                if (estado == "Activo")
                    consulta += " And p.activo = 1";
                else if (estado == "Inactivo")
                    consulta += " And p.activo = 0";



                datos.setQuery(consulta);
                datos.abrirConexion();


                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["id"];
                    aux.Numero = (int)datos.Lector["numero"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];

                    //Si los datos son nulos no los leo
                    if (!(datos.Lector["urlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["urlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.IdElemento = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.IdElemento = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;
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
