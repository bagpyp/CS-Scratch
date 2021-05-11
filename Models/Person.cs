using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable enable

namespace Scratch 
{
    public class Person 
    {
        // attributes
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Person> Friends { get; set; } = new();
        public int PersonId { get; set; }
        // public Group? Group { get; set; }
        // public int GroupId { get; set; }

        // methods
        public void Introduce() 
        {
            Console.WriteLine($"\nMy name is {Name},");
            if (Friends.Count != 0) 
            {
                Console.WriteLine("My friends are");
                Friends.ForEach(f => Console.WriteLine($"\t{f.Name}"));
            } 
            else 
            {
                Console.WriteLine("I have no friends...");
            }
        }
        public void Befriend(Person p) 
        {
            if (!Friends.Contains(p))
                Friends.Add(p);                
        }
        public void Unfriend(Person p) 
        {   
            if (!Friends.Contains(p))
                Friends.Remove(p);
        }
        // stativ methods
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
            Name = "Stranger";
        }
        public Person(string name)
        {
            Name = name;
        }
    }
}