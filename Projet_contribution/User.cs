using System;
namespace Projet_contribution.Models
{
    public class User
    {

        /* Ont va pouvoir acceder , mettre à jour plus facilement les variables à partir de ce genre de proceder */
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        private String _username;
        public String Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private String _firstname;
        public String Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private String _lastname;
        public String Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private String _email;
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private String _password;
        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _rank;
        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        private Boolean _active;
        public Boolean Active
        {
            get { return _active; }
            set { _active = value; }
        }

        private int _adresseip;
        public int Adresseip
        {
            get { return _adresseip; }
            set { _adresseip = value; }
        }

        private DateTime _registerdate;
        public DateTime Registerdate
        {
            get { return _registerdate; }
            set { _registerdate = value; }
        }
    }
}
