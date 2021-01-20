using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class Register
    {
        public List<Person> Content;

        public Register() 
        {
            Content = new List<Person>();
        }

        // Get an item
        public Person GetItem(int idToCompare) 
        {
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

        // Checks if this register holds the parsed id
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
            } 
            else
            {
                builder.Append("Person finnes ikke databasen."); 
            }

            return builder.ToString();
        }

        public string ListAll() 
        {
            StringBuilder builder = new StringBuilder();

            if (Content.Count != 0)
            {
                List<FamilyTree> familyTrees = new List<FamilyTree>();

                foreach (Person person in Content)
                {
                    if (person.familyTree != null && !familyTrees.Contains(person.familyTree))
                    {
                        familyTrees.Add(person.familyTree);
                        builder.Append(person.familyTree.ToString());
                    }
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
