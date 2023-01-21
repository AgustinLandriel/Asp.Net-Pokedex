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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !(Page is Login || Page is Default || Page is Registro)) //Si la pagina que cargo no es login, carga login
            {
                if (!Seguridad.sesionActiva(Session["traineeActivo"])) // Si no hay una sesion activa te mando a login
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

        }
    }
}