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

        public bool FiltroAvanzado { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = checkFiltroAvanzado.Checked;

            if (!Seguridad.esAdmin(Session["traineeActivo"])) // Compruebo si es admin o no para poder ver la pagina.
            {
                Session.Add("error", "No tenes permisos para ver esta pagina. Necesitas ser administrador.");
                Response.Redirect("Error.aspx");
            }

            if (!IsPostBack)
            {
                ddlCampo.Items.Insert(0, new ListItem("Seleccione un campo"));
                desabilitarCampos();
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("ListaPokemon", negocio.listarConSP());
                dgvPokemon.DataSource = Session["ListaPokemon"];
                dgvPokemon.DataBind();

            }

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

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["ListaPokemon"];

            List<Pokemon> listafiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || x.Tipo.Descripcion.ToLower().Contains(txtFiltro.Text.ToLower()));

            dgvPokemon.DataSource = listafiltrada;
            dgvPokemon.DataBind();
        }

        protected void checkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = checkFiltroAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlCampo.SelectedIndex == 0) // Si esta seleccionado "Seleccione campos", bloqueo los demas campos.
                desabilitarCampos();

            
            ddlCriterio.Items.Clear(); // Reseteo los campos

            if (ddlCampo.SelectedItem.Text == "Número")
            {
                habilitarCampos();
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");

            }
            else if (ddlCampo.SelectedItem.Text == "Tipo")
            {
                habilitarCampos();
                ddlCriterio.Items.Add("Fuego");
                ddlCriterio.Items.Add("Agua");
                ddlCriterio.Items.Add("Tierra");
                
            }
            else if (ddlCampo.SelectedItem.Text == "Nombre")
            {
                habilitarCampos();
                ddlCriterio.Items.Add("Coincide con");
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();

                //Recupero los valores de los campos
                string campo = ddlCampo.SelectedItem.ToString();
                string criterio = ddlCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                string estado = ddlEstado.SelectedItem.ToString();

                //Le cargo la lista filtrada a la grilla
                dgvPokemon.DataSource = negocio.filtroAvanzado(campo, criterio, filtro, estado);
                dgvPokemon.DataBind();
            }
            catch (Exception)
            {

                Response.Redirect("error.aspx");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            txtFiltroAvanzado.Text = "";
            desabilitarCampos();
        }

        private void desabilitarCampos()
        {
            txtFiltroAvanzado.Enabled = false;
            ddlCriterio.Enabled = false;
            ddlEstado.Enabled = false;
            ddlCampo.SelectedIndex = 0; 
        }
        private void habilitarCampos()
        {
            ddlCriterio.Enabled = true;
            ddlEstado.Enabled = true;
            txtFiltroAvanzado.Enabled = true;
        }
    }
}