using KomodoInsurance_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repo
{
    public class DeveloperRepo
    {
        private List<Developer> _listOfDevelopers = new List<Developer>();

        private int _count = 0;

        public bool CreateDeveloper(Developer developer)
        {
            if (developer is null)
            {
                return false;
            }

            _count++;
            developer.Id = _count;
            _listOfDevelopers.Add(developer);
            return true;
        }

        public List<Developer> GetAllDevelopers()
        {
            return _listOfDevelopers;
        }

        public Developer GetDeveloperById(int id)
        {
            foreach (Developer developer in _listOfDevelopers)
            {
                if (developer.Id == id)
                {
                    return developer;
                }
            }

            return null;
        }

        public bool UpdateDeveloper(int id, Developer developer)
        {
            Developer existingDeveloper = GetDeveloperById(id);

            if (existingDeveloper != null)
            {
                existingDeveloper.FirstName = developer.FirstName;
                existingDeveloper.LastName = developer.LastName;
                existingDeveloper.HasPluralsightAccess = developer.HasPluralsightAccess;
                return true;
            }

            return false;
        }

        public bool DeleteDeveloper(int id)
        {
            Developer developer = GetDeveloperById(id);

            if (developer is null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count();

            _listOfDevelopers.Remove(developer);

            if (initialCount > _listOfDevelopers.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
