using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace controlador
{
    public static class Seguridad
    {

        public static bool sesionActiva(object user)
        {
            // Mando la session traineeActivo por parametro

            Trainee trainee = user != null ? (Trainee) user : null;  //Si no es nulo, creo la instancia del usuario

            if (trainee != null && trainee.Id != 0) //Compruebo si no es nulo y su id es distinto a cero 
            {
                return true;
            }

            return false;
        }



        public static bool esAdmin(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null; 

            return trainee != null ? trainee.Admin : false; //Devuelve true si es ADMIN o false si no lo es
        }
    }
}
