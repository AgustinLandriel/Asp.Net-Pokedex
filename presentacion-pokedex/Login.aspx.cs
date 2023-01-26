using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;



namespace presentacion_pokedex
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio traineeNegocio = new TraineeNegocio();

            try
            {
                if (!Validacion.validaTextoVacio(txtEmail) || !Validacion.validaTextoVacio(txtPassword))
                {
                    Session.Add("error", "Debes completar ambos campos.");
                    Response.Redirect("error.aspx");
                }

                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;

                if (traineeNegocio.Login(trainee))
                {
                    Session.Add("traineeActivo", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        /*  private void Page_Error(object sender, EventArgs e)
          {
              Exception exc = Server.GetLastError();

              Session.Add("error", exc.ToString());
              Response.Redirect("error.aspx");
          }*/
    }

}