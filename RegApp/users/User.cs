using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Users
{
    /// <summary>
    /// This is the user class where either a student or an administrator can register
    /// </summary>

    public abstract class User
    {
        #region fields
        public string firstname;
        public string lastname;
        protected string password;
        private string email;
        private int id;
        #endregion fields

        #region constructors
        //constructors
        public User()
        { 
        }

        public User(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public User(string firstname, string lastname, string password, string email, int id)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
            this.email = email;
            this.id = id;
        }

        #endregion constructors

        #region properties
        //fullname property
        public string Fullname
        {
            get
            {
                string fullname = $"{this.firstname} {this.lastname}";  // using string interpolation pg. 51
                return fullname;
            }
        }

        //firstname property
        public string Firstname
        {
            get { return this.firstname; }
            set { this.firstname = value; }
        }

        //lasstname property
        public string Lastname
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        //email property
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        //password property
        public string Password
        {
            get { return this.password; }
        }

        //id property
        public int Id
        {
            get { return this.id; }
        }

        #endregion properties

        #region methods
        public override string ToString()
        {
            string result = "";
            result += Fullname;
            result += "\n";
            result += $"email: {Email}";
            result += "\n";

            return result;
        }

        #endregion methods
    }
}
