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
        //public FamilyGroup family;

        public Person(int id = -1, string firstName = "", string lastName = "", int birthYear = -1, int deathYear = -1, Person mother = null, Person father = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            DeathYear = deathYear;
            Mother = mother;
            Father = father;
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

        public string GetDescription()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(GetDescriptionShort(true));
            if (BirthYear != -1) builder.Append($" Født: {BirthYear}");
            if (DeathYear != -1) builder.Append($" Død: {DeathYear}");
            if (Father != null) builder.Append($" Far: {Father.GetDescriptionShort()}");
            if (Mother != null) builder.Append($" Mor: {Mother.GetDescriptionShort()}");

            return builder.ToString();
        }

        // Resolve on adding
        public bool HasParent(List<Person> register) 
        {
            foreach (var person in register)
            {
                if (person.Mother == Mother || person.Father == Father) return true;
            }

            return false;
        }

        // Resolve on adding
        public List<int> FindChildren(List<Person> register)
        {
            // Setup result list
            List<int> result = new List<int>();

            foreach (var person in register) 
            {
                // If this is the father or mother of the person
                if (person.Father == this || person.Mother == this) result.Add(person.Id);
            }

            return result;
        }
    }
}
