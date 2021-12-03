using KomodoInsurance_POCO;
using KomodoInsurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    public class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DeveloperTeamRepo _teamRepo = new DeveloperTeamRepo();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Select a Menu Option:\n" +
                    "1. Create a New Developer\n" +
                    "2. Create a New Developer Team\n" +
                    "3. View All Developers\n" +
                    "4. View All Developer Teams\n" +
                    "5. View a Developer by ID\n" +
                    "6. View a Developer Team by ID\n" +
                    "7. Add a Developer to a Developer Team\n" +
                    "8. Remove a Developer from a Developer Team\n" +
                    "9. Display Developers that do not have Pluralsight Access\n" +
                    "10. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        CreateDeveloperTeam();
                        break;
                    case "3":
                        ViewAllDevelopers();
                        break;
                    case "4":
                        ViewAllDeveloperTeams();
                        break;
                    case "5":
                        ViewDeveloperById();
                        break;
                    case "6":
                        ViewDeveloperTeamById();
                        break;
                    case "7":
                        AddDeveloperToTeam();
                        break;
                    case "8":
                        RemoveDeveloperFromTeam();
                        break;
                    case "9":
                        ViewDevelopersWithoutPluralsightAccess();
                        break;
                    case "10":
                        Console.WriteLine("See you again soon!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not an option, please try again\n");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        private void CreateDeveloper()
        {
            Console.Clear();

            Developer newDev = new Developer();

            Console.WriteLine("Enter the developers first name:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the developers last name:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("Does the developer have Pluralsight access? (y/n)");
            string pluralsightAccess = Console.ReadLine().ToLower();

            if(pluralsightAccess == "y")
            {
                newDev.HasPluralsightAccess = true;
            } else
            {
                newDev.HasPluralsightAccess = false;
            }

            bool createSuccess = _developerRepo.CreateDeveloper(newDev);

            if (createSuccess)
            {
                Console.WriteLine("Developer successfully created.");
            } else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }
        }
        private void CreateDeveloperTeam()
        {
            Console.Clear();

            DeveloperTeam newDevTeam = new DeveloperTeam();

            Console.WriteLine("Enter the Team Name:");
            newDevTeam.TeamName = Console.ReadLine();

            bool createSuccess = _teamRepo.CreateDeveloperTeam(newDevTeam);

            if (createSuccess)
            {
                Console.WriteLine("Team successfully crated, would you like to add developers now? (y/n)");
                string addDevs = Console.ReadLine().ToLower();

                if (addDevs == "y")
                {
                    AddDeveloperToTeam();
                }
            } else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }
            
        }
        private void ViewAllDevelopers()
        {
            Console.Clear();

            List<Developer> devs = _developerRepo.GetAllDevelopers();
            
            foreach(Developer dev in devs)
            {
                DisplayDeveloper(dev);
            }
        }
        private void ViewAllDeveloperTeams()
        {
            Console.Clear();

            List<DeveloperTeam> devTeams = _teamRepo.GetAllDeveloperTeams();

            foreach(DeveloperTeam devTeam in devTeams)
            {
                DisplayDeveloperTeam(devTeam);
            }
        }
        private void ViewDeveloperById()
        {
            Console.Clear();

            Console.WriteLine("Enter the id of the developer you would like to see:");

            int developerId = int.Parse(Console.ReadLine());

            Developer dev = _developerRepo.GetDeveloperById(developerId);

            DisplayDeveloper(dev);
        }
        private void ViewDeveloperTeamById()
        {

        }
        private void AddDeveloperToTeam()
        {
            ViewAllDeveloperTeams();

            Console.WriteLine("Enter the id of the team you would like to add a developer to:");

            int teamId = int.Parse(Console.ReadLine());

            ViewAllDevelopers();

            Console.WriteLine("Enter the id of the developer you would like to add to the team:");

            int developerId = int.Parse(Console.ReadLine());

            Developer dev = _developerRepo.GetDeveloperById(developerId);

            bool addSuccessful = _teamRepo.AddDeveloperToTeam(teamId, dev);

            if(addSuccessful)
            {
                Console.WriteLine("Developer successfully added.");
            } else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }

        }
        private void RemoveDeveloperFromTeam()
        {

        }
        private void ViewDevelopersWithoutPluralsightAccess()
        {

        }

        private void DisplayDeveloper(Developer dev)
        {
            Console.WriteLine("******************************");
            Console.WriteLine($"Developer ID: {dev.Id}");
            Console.WriteLine($"Name: {dev.FirstName} {dev.LastName}");
            Console.WriteLine($"Has Plural Sight Access: {dev.HasPluralsightAccess}");
            Console.WriteLine("******************************");
        }

        private void DisplayDeveloperTeam(DeveloperTeam devTeam)
        {
            Console.WriteLine("******************************");
            Console.WriteLine($"Team ID: {devTeam.Id}");
            Console.WriteLine($"Team Name: {devTeam.TeamName}");
            if (devTeam.Developers != null)
            {
                Console.WriteLine("Developers:");
                foreach (Developer dev in devTeam.Developers)
                {
                    DisplayDeveloper(dev);
                }
            }

        }


    }
}
