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
        public bool activo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !(Page is Login || Page is Default || Page is Registro)) //Habilito solo las paginas de Logear,Default y Registro para los usuarios sin cuenta
            {
                if (!Seguridad.sesionActiva(Session["traineeActivo"])) // Si no hay una sesion activa te mando a login
                {
                    
                    Response.Redirect("Login.aspx", false);
                }
            }

            //Compruebo si esta iniciado sesion 
            if (Seguridad.sesionActiva(Session["traineeActivo"]))
                activo = true;
            else
                activo = false;

           
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Cerrar session
            Session.Clear();
            Response.Redirect("Login.aspx",false);
        }
    }
}