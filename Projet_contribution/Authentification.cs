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
        public User user = new User();
        public Boolean check_login(String username)
        {
            Boolean reponse = false;
            Database database = new Database();
            user= database.Get_user(username);
            if(user!=null && user.Active==true)
            {
                reponse = true;
            }
            return reponse;
        }

                                                                /* D'autres méthodes en lien avec l'authentification peuvent étre créer */
    }
}
