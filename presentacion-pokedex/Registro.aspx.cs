using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace presentacion_pokedex
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                EmailService emailService = new EmailService();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                Trainee user = new Trainee();

                //Creo el usuario con email y pass
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                //Recupero el ID cuando se registra.
                user.Id = traineeNegocio.CrearUser(user);

                //Cuando se registra, creo la sesion asi entra automaticamente.
                Session.Add("traineeActivo", user);


                //Envio un email de bienvenida
              /* emailService.armarCorreo(user.Email, "Bienvenida Trainner", "Hola, te damos la bienvenida a la aplicacion");
                emailService.enviarCorreo();*/
                Response.Redirect("Default.aspx",false);
            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx");
            }
        }
    }
}