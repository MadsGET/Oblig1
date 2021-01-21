using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class FamilyTree
    {
        public Person Father;
        public Person Mother;
        public Person[] Children;

        public FamilyTree(params Person[] children) 
        {
            // Change to mother or father
            Children = children;
        }

        public void Join(Person target) 
        {
            // Set mother or father
            if (Father == null) Father = target.familyTree.Father;
            if (Mother == null) Mother = target.familyTree.Mother;
            
            // Set familyTree for target.
            target.familyTree = this;
        }

        public bool Compare(FamilyTree other)
        {
            // Is the length of children arrays the same for both?
            if (Children.Length != other.Children.Length) return false;          
            
            // Check each child
            for (int i = 0; i < Children.Length; i++) 
            {
                // If a child is not the same on both arrays
                if (Children[i] != other.Children[i]) return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (Mother != null) builder.Append(Mother.GetDescription() + "\n");
            if (Father != null) builder.Append(Father.GetDescription() + "\n");

            builder.Append("  Barn:\n");

            foreach (var child in Children) 
            {
                builder.Append("    ");
                builder.Append(child.GetDescription(false));
                builder.Append("\n");
            }

            return builder.ToString();
        }

        public void AddParent(Person parent, bool isMother) 
        {
            if (isMother)
            {
                Mother = parent;
            }
            else 
            {
                Father = parent;
            }
        }
    }
}
