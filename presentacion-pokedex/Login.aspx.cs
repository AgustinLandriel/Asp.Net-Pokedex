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
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;

               if(traineeNegocio.Login(trainee))
                {
                    Session.Add("traineeActivo", trainee);
                    Response.Redirect("MiPerfil.aspx",false);
                }
                else
                {
                    Session.Add("error", "Email y/o contraseña incorrecta");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }
        }
    }
}