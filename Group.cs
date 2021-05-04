using System;
using System.Collections.Generic;

namespace Scratch 
{
    public class Group
    {
        public List<Person> People { get; set; }
        public bool[,] Graph { get; set; } 
        // methods
        public void ListMembers() 
        {
            this.People.ForEach(p => Console.WriteLine(p.Name));
        }
        // constructors
        public Group(params string[] names)
        {
            foreach (string n in names) 
            {
            if (this.People == null)
                this.People = new List<Person> {new Person(n)};
            else 
                this.People.Add(new Person(n));
            }
        }   
    }
}