using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentmanagement.Core.Mystudent_class
{
    public class Mymodelcs
    {
        public int StudentId { get; set; }
        public string firstname { get; set; }
        public string secondname { get; set; }
        public System.DateTime Studentsdob { get; set; }
        public int Age { get; set; }
        public string Favoritesubject { get; set; }
        public string InterestedCourse { get; set; }
        public int Mathsmark { get; set; }
        public int ChemistryMark { get; set; }
        public int CompMark { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
    }
}
