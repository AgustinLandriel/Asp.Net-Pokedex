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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    //Cargo el perfil con los datos
                    if (Seguridad.sesionActiva(Session["traineeActivo"]))
                    {
                        Trainee user = (Trainee)Session["traineeActivo"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        imgNuevoPerfil.ImageUrl = !string.IsNullOrEmpty(user.ImagenPerfil) ? "~/Images/" + user.ImagenPerfil : "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";
                    }

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {

                Page.Validate(); // Valida la pagina
                if (!Page.IsValid)
                {
                    return; //Si no fue validado el campo, cierra la ejecucion
                }

                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["traineeActivo"];

                if (txtImagen.PostedFile.FileName != null)
                {
                    string ruta = Server.MapPath("./Images/");//Asigno la ruta de la carpeta imagen
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); //Guardo la imagen en la carpeta
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                //Guardo el perfil del trainee
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                negocio.Actualizar(user);


                //Cambio img del avatar
                Image imgAvatar = (Image)Master.FindControl("imgAvatar");
                imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;   // el ~ me pone en la ruta de la carpeta donde esta la img
                imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;

                Response.Redirect("MiPerfil.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx");
            }
        }
    }
}