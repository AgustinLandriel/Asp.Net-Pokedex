﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace negocio
{
    public static class Validacion
    {

        public static bool validaTextoVacio (object control)
        {
            if(control is TextBox texto) // Si control es de tipo textbox
            {
                //Si el control es vacio, retorna false
                if(string.IsNullOrEmpty(texto.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
