using KomodoInsurance_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class DeveloperTeamRepo
    {
        private List<DeveloperTeam> _listOfDeveloperTeams = new List<DeveloperTeam>();

        private int _count = 0;

        public bool CreateDeveloperTeam(DeveloperTeam developerTeam)
        {
            if(developerTeam is null)
            {
                return false;
            }

            _count++;
            developerTeam.Id = _count;
            _listOfDeveloperTeams.Add(developerTeam);
            return true;
                
        }

        public List<DeveloperTeam> GetAllDeveloperTeams()
        {
            return _listOfDeveloperTeams;
        }

        public DeveloperTeam GetDeveloperTeamById(int id)
        {
            foreach(DeveloperTeam developerTeam in _listOfDeveloperTeams)
            {
                if(developerTeam.Id == id)
                {
                    return developerTeam;
                }
            }

            return null;
        }
        
        public bool AddDeveloperToTeam(int teamId, Developer developer)
        {
            DeveloperTeam developerTeam = GetDeveloperTeamById(teamId);

            if(developerTeam.Developers != null && developer != null)
            {
                developerTeam.Developers.Add(developer);  // This is throwing an error.
                return true;
            } else if(developerTeam != null && developer != null)
            {
                developerTeam.Developers = new List<Developer>() { developer };
                return true;
            } else
            {
                return false;
            }
        }

        public bool RemoveDeveloperFromteam(int teamId, Developer developer)
        {
            DeveloperTeam developerTeam = GetDeveloperTeamById(teamId);


            if(developerTeam.Developers != null && developer != null)
            {
                int initialTeamCount = developerTeam.Developers.Count();

                foreach(Developer person in developerTeam.Developers)
                {
                    if(person.Id == developer.Id)
                    {
                        developerTeam.Developers.Remove(developer);
                        if(initialTeamCount > developerTeam.Developers.Count())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

    }
}
