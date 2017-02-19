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

        public Major(string title)
        {
            this.title = title;
        }

        public string Title { get; set; }
        public int ID { get; set; }
    }
}
