using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_POCO
{
    public class DeveloperTeam
    {
        public int Id { get; set; }
        public List<Developer> Developers { get; set; }
        public string TeamName { get; set; }
        
    }
}
