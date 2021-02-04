using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class FamilyApp
    {
        public string WelcomeMessage => ShowHelpText();
        public readonly string CommandPrompt = "-> Venter på kommando.\n";
        public readonly string InvalidCommand = "\n-> Ukjent kommando.\n";

        // This is the content of the register
        public List<Person> Content;

        public FamilyApp(params Person[] persons) 
        {
            Content = new List<Person>();

            foreach (Person person in persons) 
            {            
                // Add this person to the register
                AddItem(person);
            }    
        }

        public string HandleCommand(string parameter, bool isUnitTest = false)
        {
            string[] convertedParams = parameter.Split(" "); 
            
            if(!isUnitTest) Console.Clear();

            switch (convertedParams[0].ToLower())
            {
                default: return InvalidCommand;
                case "hjelp": return ShowHelpText();
                case "liste": return ListAll();
                case "vis":
                    int result = -1;
                    if (convertedParams.Length == 2) int.TryParse(convertedParams[1], out result);
                    return ListItem(result);
            }
        }

        private string ShowHelpText()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Liste av gyldige kommandoer. \n");
            builder.Append("-> Hjelp    : Viser en liste av kommandoer.\n");
            builder.Append("-> Liste    : Henter all lagret personalia fra registeret.\n");
            builder.Append("-> Vis <ID> : Henter personalia fra registeret med bruk av ID feltet.");

            return builder.ToString();
        }

        // Get an item
        public Person GetItem(int idToCompare)
        {
            // Loop through each item in content and find the correct one.
            foreach (var item in Content)
            {
                if (item.Id == idToCompare) return item;
            }

            return null;
        }

        // Add an item
        public void AddItem(Person item)
        {
            Content.Add(item);
        }

        // Checks if this register contains the parsed ID
        public bool Contains(int idToCompare)
        {
            foreach (var person in Content)
            {
                if (person.Id == idToCompare) return true;
            }

            return false;
        }

        // Lists a specific item within our register.
        public string ListItem(int id)
        {
            StringBuilder builder = new StringBuilder();
            Person fetchedPerson = GetItem(id);

            if (fetchedPerson != null)
            {
                builder.Append(fetchedPerson.GetDescription());
                bool hasChildren = false;

                foreach (Person p in Content) 
                {
                    if (p.Father == fetchedPerson || p.Mother == fetchedPerson) 
                    {
                        if (!hasChildren) 
                        {
                            builder.Append("\n");
                            builder.Append("  Barn:\n");
                            hasChildren = true;
                        }
                        builder.Append($"    {p.GetDescription(false)}\n");
                    }
                }
            }
            else
            {
                builder.Append("Person finnes ikke databasen.");
            }

            return builder.ToString();
        }

        public string ListAll()
        {
            StringBuilder builder = new StringBuilder(1024);

            if (Content.Count != 0)
            {
                // Loop through each person in register
                foreach (Person person in Content)
                {                 
                    builder.Append(person.GetDescription() + "\n");
                }
            }
            else
            {
                builder.Append("Databasen er tom.");
            }

            return builder.ToString();
        }
    }
}
