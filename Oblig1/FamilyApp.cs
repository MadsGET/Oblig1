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
            foreach (Person p in persons) 
            {
                AddItem(p);
            }
        }

        public string HandleCommand(string parameter)
        {
            string[] convertedParams = parameter.Split(" "); 
            //Console.Clear();

            switch (convertedParams[0].ToLower())
            {
                default: return InvalidCommand;
                case "hjelp": return $"{ShowHelpText()}";
                case "liste": return $"{ListAll()}";
                case "vis":
                    int result = -1;
                    if (convertedParams.Length == 2) int.TryParse(convertedParams[1], out result);
                    return $"{ListItem(result)}";
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
