using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace presentacion_pokedex
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        //ERROR GENERICO
      /*  void Application_Error(object sender, EventArgs e)
        {
            //Capturo el ultimo error 
            Exception exc = Server.GetLastError();
            Session.Add("error", exc.ToString());
            //Response.Redirect("error.aspx");

            Server.Transfer("error.aspx");
        }*/ 


    }
}