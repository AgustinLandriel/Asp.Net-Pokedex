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

                //Si el parametro que me viene por id es no es nulo, se modifica
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());

                    //Busco por el ID y me traigo el pokemon

                    Pokemon pokemon = ((List<Pokemon>)Session["ListaPokemon"]).Find(x => x.Id == id);

                    textNumero.Text = pokemon.Numero.ToString();
                    textNombre.Text = pokemon.Nombre;
                    textDescripcion.Text = pokemon.Descripcion;
                    textImagen.Text = pokemon.UrlImagen;
                    ddlTipo.SelectedValue = pokemon.Tipo.IdElemento.ToString();
                    ddlDebilidad.SelectedValue = pokemon.Debilidad.IdElemento.ToString();
                    btnAgregar.Visible = false;
                }
                else
                {
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                    btnEliminarLogico.Visible = false;
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

                if (Request.QueryString["id"] != null )
                {
                    negocio.modificarPokemonSP(pokemon);
                }
                else
                {
                    negocio.agregarPokemonSP(pokemon);
                }

                Response.Redirect("ListaPokemon.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                int id = int.Parse(Request.QueryString["id"].ToString());

                negocio.eliminarFisicamenteSP(id);

                Response.Redirect("ListaPokemon.aspx",false);
            }
            catch (Exception ex)
            {
                
                Response.Redirect("Error.aspx");

            }
        }

        protected void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                int id = int.Parse(Request.QueryString["id"].ToString());
                negocio.eliminarLogicoSP(id);
                Response.Redirect("ListaPokemon.aspx", false);
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }
        }
    }
}