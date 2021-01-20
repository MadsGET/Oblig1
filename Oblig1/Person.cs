using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class Person
    {
        public int Id, BirthYear, DeathYear;
        public string FirstName, LastName;
        public Person Mother, Father;
        public FamilyTree familyTree;

        public Person(int id = -1, string firstName = "", string lastName = "", int birthYear = -1, int deathYear = -1, Person mother = null, Person father = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            DeathYear = deathYear;
            Mother = mother;
            Father = father;
            familyTree = null;
        }

        public string GetName() 
        {
            return FirstName + " " + LastName;
        }

        public string GetID() 
        {
            return $"(Id={Id})";
        }

        public string GetDescriptionShort(bool includeLastName = false) 
        {
            StringBuilder builder = new StringBuilder();

            if (FirstName != "") builder.Append($"{FirstName} ");
            if (LastName != "" && includeLastName) builder.Append($"{LastName} ");
            builder.Append(GetID());
            return builder.ToString();
        }

        public string GetDescription(bool displayParents = true)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(GetDescriptionShort(true));
            if (BirthYear != -1) builder.Append($" Født: {BirthYear}");
            if (DeathYear != -1) builder.Append($" Død: {DeathYear}");
            if (Father != null && displayParents) builder.Append($" Far: {Father.GetDescriptionShort()}");
            if (Mother != null && displayParents) builder.Append($" Mor: {Mother.GetDescriptionShort()}");
            builder.Append("\n");
            return builder.ToString();
        }
    }
}
