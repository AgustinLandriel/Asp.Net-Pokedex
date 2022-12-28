using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controlador;
using dominio;

namespace presentacion_pokedex
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> ListPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            ListPokemon = negocio.listarConSP();

            if (!IsPostBack)
            {
                repPokemon.DataSource = ListPokemon;
                repPokemon.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            //Capturo a traves de un control el command argument
            string valor = ((Button)sender).CommandArgument;
        }
    }
}