using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class Register
    {
        private static List<Person> _content;

        public Register() 
        {
            _content = new List<Person>();
        }

        // Get an item
        public Person GetItem(int idToCompare) 
        {
            foreach (var item in _content) 
            {
                if (item.Id == idToCompare) return item;
            }

            return null;
        }

        // Add an item
        public void AddItem(Person item) 
        {
            _content.Add(item);
        }

        // Checks if this register holds the parsed id
        public bool Contains(int idToCompare) 
        {
            foreach (var person in _content) 
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

            if (_content.Count != 0)
            {
                foreach (var person in _content) 
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
