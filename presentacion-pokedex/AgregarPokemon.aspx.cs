using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using controlador;

namespace presentacion_pokedex
{
    public partial class AgregarPokemon : System.Web.UI.Page
    {
        public string urlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocioElemento = new ElementoNegocio();

                    Session.Add("ListaElementos", negocioElemento.getElementos());

                    //Cargo los drop down list

                    //Tipo
                    ddlTipo.DataSource = Session["ListaElementos"];
                    ddlTipo.DataValueField = "IdElemento";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();
                    //Debilidad
                    ddlDebilidad.DataSource = Session["ListaElementos"];
                    ddlDebilidad.DataValueField = "IdElemento";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("ERROR", ex);
                //Redirecciono a pantalla error
                Response.Redirect("Error.aspx");
            }
    

        }

        protected void textImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                urlImagen = textImagen.Text;
            }
            catch (Exception)
            {
                urlImagen = "http://atrilco.com/wp-content/uploads/2017/11/ef3-placeholder-image.jpg";
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo el pokemon y le asigno los campos
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon pokemon = new Pokemon();           
                pokemon.Numero = int.Parse(textNumero.Text);
                pokemon.Nombre = textNombre.Text;
                pokemon.Descripcion = textDescripcion.Text;
                pokemon.UrlImagen = textImagen.Text;
                pokemon.Tipo = new Elemento();
                pokemon.Tipo.IdElemento = int.Parse(ddlTipo.SelectedValue);
                pokemon.Debilidad = new Elemento();
                pokemon.Debilidad.IdElemento = int.Parse(ddlDebilidad.SelectedValue);

                //negocio.agregarPokemon(pokemon);
                negocio.agregarPokemonSP(pokemon);
                Response.Redirect("ListaPokemon.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}