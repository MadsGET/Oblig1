using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class FamilyApp : Register
    {
        public readonly string WelcomeMessage = "-> Slektstre program - Oblig1.";
        public readonly string CommandPrompt = "-> Venter på kommando.\n";
        public readonly string InvalidCommand = "\n-> Ukjent kommando.\n";

        public FamilyApp(params Person[] persons) 
        {
            foreach (Person person in persons) 
            {
                bool isMother = false;
                List <Person> children = new List<Person>();

                foreach (Person potentialChild in persons) 
                {
                    if (potentialChild.Father == person || potentialChild.Mother == person) 
                    {
                        isMother = (potentialChild.Mother == person);
                        children.Add(potentialChild);
                    }
                }

                if (children.Count != 0) 
                {
                    person.familyTree = new FamilyTree(children.ToArray());
                    person.familyTree.AddParent(person, isMother);
                }

                // Add this person to the register
                AddItem(person);
            }

            // Loop through and join any family trees that are seperated
            for (int i = 0; i < persons.Length; i++) 
            {            
                Person selected = Content[i];

                // If this person is childless.
                if (selected.familyTree == null) continue;

                foreach (Person person in Content) 
                {
                    // If this person is not the same as selected and is not childless
                    if (person != selected && person.familyTree != null) 
                    {                     
                        if (selected.familyTree.Compare(person.familyTree)) 
                        {
                            // Join the familytrees
                            selected.familyTree.Join(person);
                        }
                    }
                }
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
    }
}
