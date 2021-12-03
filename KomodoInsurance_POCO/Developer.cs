using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_POCO
{
    public class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasPluralsightAccess { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, bool hasPluralsightAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            HasPluralsightAccess = hasPluralsightAccess;
        }
    }
}
