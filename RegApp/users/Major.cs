using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Users
{
    public class Major
    {
        int id;
        string title;

        public Major()
        {
        }

        public Major(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
    }
}
