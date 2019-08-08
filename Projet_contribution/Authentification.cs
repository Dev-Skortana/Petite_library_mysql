using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_contribution.Services;
namespace Projet_contribution.Models
{
    public class Authentification
    {
        public Boolean check_login()
        {
            Boolean reponse = false;
            Database database = new Database();
            User utilisateur= database.Get_user("exemple");
            if(utilisateur!=null && utilisateur.Active==true)
            {
                reponse = true;
            }
            return reponse;
        }

                                                                /* D'autres méthodes en lien avec l'authentification peuvent étre créer */
    }
}
