using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class Register
    {
        // This is the content of the register
        public List<Person> Content;

        public Register() 
        {
            Content = new List<Person>();
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
                if (fetchedPerson.familyTree != null)
                {
                    builder.Append(fetchedPerson.familyTree.ToString());
                }
                else 
                {
                    builder.Append(fetchedPerson.GetDescription());
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
                List<FamilyTree> familyTrees = new List<FamilyTree>();

                // Loop through each person in register
                foreach (Person person in Content)
                {
                    // If the person has a family tree
                    if (person.familyTree != null)
                    {
                        // Check if this family tree has already been listed
                        if (!familyTrees.Contains(person.familyTree)) 
                        {
                            // If not add to the list and append the family tree
                            familyTrees.Add(person.familyTree);
                            builder.Append(person.familyTree.ToString());
                        }
                    }
                    else if (person.Mother == null && person.Father == null) 
                    {
                        builder.Append(person.GetDescription() + "\n");
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
