using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Projet_contribution.Models;
namespace Projet_contribution.Services
{
    public class Database
    {
                    /* Variables ayant une valeur fixe qui ne peut pas étre changer ,elle serviront pour se connecter à la base de données */
         private const String SERVER = "localhost"; /* Local(cette machine) */
         private const String DATABASE = "nomexemple"; /* Nom de la base de données */
         private const String IDENTIFIANT = "admin"; /* Par défault */
         private  const String PASSWORD = "admin"; /* Par défault */
         private const String PORT = "3304"; /* Un autre port peut etre utiliser */
         private const String CHAINE_CONNEXION= "datasource=" + SERVER + "; database=" + DATABASE + "; port=" + PORT + "; username=" + IDENTIFIANT + "; password=" + PASSWORD + "; SslMode=none;";

         private MySqlConnection connection = new MySqlConnection(CHAINE_CONNEXION);

                    /* Ces deux methodes en privé permettront d'utiliser l'objet Database de façon plus facile (Elle peuvent etre appeler que dans cette classe à cause du mot clé private) */
        private void open_connection()
        {
            connection.Open();
        }
        private void close_connection()
        {
            connection.Close();
        }

        /* Cette méthode évite la répétition de code */
        private User remplissage_utilisateur(MySqlDataReader lecture)
        {
            User result = new User();
            result.Id = int.Parse(lecture["id"].ToString());
            result.Username = lecture["username"].ToString();
            result.Firstname = lecture["firstname"].ToString();
            result.Lastname = lecture["lastname"].ToString();
            result.Email = lecture["email"].ToString();
            result.Password = lecture["password"].ToString();
            result.Rank = int.Parse(lecture["rank"].ToString());
            if (lecture["active"].ToString()=="1")
            {
                result.Active = true;
            }
            else if(lecture["active"].ToString() == "0")
            {
                result.Active = false;
            }
            result.Adresseip = int.Parse(lecture["adresseip"].ToString());
            result.Registerdate = DateTime.Parse(lecture["registerdate"].ToString()); ;
            return result;
        }

                                 /* Ces deux méthodes contiennent du code qui interagissent avec la base de données pour récuperer un ou plusieurs utilisateur(s) */
        public User Get_user(String username)
        {
            open_connection();
            MySqlCommand cmd = new MySqlCommand("Select * from users where username=@username", connection);
            cmd.Parameters.Add("@username",MySqlDbType.VarChar).Value=username;
            MySqlDataReader lecture = cmd.ExecuteReader();
            User utilisateure = null;
            if (lecture.Read())
            {
                utilisateure = remplissage_utilisateur(lecture);
            }
            close_connection();
            return utilisateure;
        }
        public List<User> Get_list_users()
        {
            open_connection();
            MySqlCommand cmd = new MySqlCommand("Select * from users", connection);
            MySqlDataReader lecture = cmd.ExecuteReader();
            List<User> liste_utilisateures = new List<User>();
            while (lecture.Read())
            {
                User utilisateure = remplissage_utilisateur(lecture);
                liste_utilisateures.Add(utilisateure);
            }
            close_connection();
            if (liste_utilisateures.Count == 0)
            {
                liste_utilisateures = null;
            }
            return liste_utilisateures;
        }
    }




}

