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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.sesionActiva(Session["traineeActivo"])) // Si no hay una sesion activa te mando a login
            {
                Response.Redirect("Login.aspx", false);
            }

            //Cargo el perfil con los datos
            if ((Trainee)Session["traineeActivo"] != null)
            {

                Trainee trainee = (Trainee)Session["traineeActivo"];
                txtEmail.Text = trainee.Email;
                txtEmail.Enabled = false;
                txtNombre.Text = trainee.Nombre;
                txtApellido.Text = trainee.Apellido;
                imgNuevoPerfil.ImageUrl = "~/Images/" + trainee.ImagenPerfil;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            TraineeNegocio negocio = new TraineeNegocio();

            try
            {
                //Asigno la ruta de la carpeta imagen
                string ruta = Server.MapPath("./Images/");
                Trainee user = (Trainee)Session["traineeActivo"];

                //Guardo la imagen en la carpeta
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

                //Guardo el perfil del trainee
                user.Nombre = txtNombre.Text;
                user.Apellido = txtNombre.Text;
                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                negocio.Actualizar(user);


                //Cambio img del avatar
                Image imgAvatar = (Image)Master.FindControl("imgAvatar");
                imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;   // el ~ me pone en la ruta de la carpeta donde esta la img


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}