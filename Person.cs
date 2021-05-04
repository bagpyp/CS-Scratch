using System;
using System.Collections.Generic;

namespace Scratch 
{
    public class Person 
    {
        // attributes
        public string Name { get; set; }
        public List<Person> Friends { get; set; }

        // methods
        public void Introduce() 
        {
            Console.WriteLine($"\nMy name is {this.Name},");
            if (this.Friends != null && this.Friends.Count != 0) 
            {
                Console.WriteLine("My friends are");
                this.Friends.ForEach(f => Console.WriteLine($"\t{f.Name}"));
            } 
            else 
            {
                Console.WriteLine("I have no friends...");
            }
        }
        public void Befriend(Person p) 
        {
            if (this.Friends == null) 
                this.Friends = new List<Person>() {p};
            else if (this.Friends.Contains(p))
                {}
            else
                this.Friends.Add(p);
        }
        public void Unfriend(Person p) 
        {   
            if (this.Friends == null) 
                {}
            else if (this.Friends.Contains(p))
                this.Friends.Remove(p);
            else
                {}
        }

        public static void CreateFriendship(Person p1, Person p2) 
        {
            p1.Befriend(p2);
            p2.Befriend(p1);
        }
        public static void EndFriendship(Person p1, Person p2) 
        {
            p1.Unfriend(p2);
            p2.Unfriend(p1);
        }
        // constructors
        public Person()
        {
            this.Name = "Stranger";
        }
        public Person(string name)
        {
            this.Name = name;
        }
    }
}