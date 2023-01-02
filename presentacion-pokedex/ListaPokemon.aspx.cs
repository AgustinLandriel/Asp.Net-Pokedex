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

    public partial class ListaPokemon : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
           
            PokemonNegocio negocio = new PokemonNegocio();
            Session.Add("ListaPokemon", negocio.listarConSP());
            dgvPokemon.DataSource = Session["ListaPokemon"];
            dgvPokemon.DataBind();

        }

        protected void dgvPokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //A cada pagina le cargo la grilla 
            dgvPokemon.PageIndex = e.NewPageIndex;
            dgvPokemon.DataBind();
        }

        protected void dgvPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string id = ((Button)sender).CommandArgument;
            string id = dgvPokemon.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarPokemon.aspx?id=" + id);

        }
    }
}