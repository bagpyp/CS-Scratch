using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scratch 
{
    public class Person
    {
        // attributes
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Friendship> Friendships { get; set; } = new();
        public List<Friendship> FriendshipsFrom { get; set; } = new();

        // [ForeignKey("Id")]
        // public int OtherPersonId { get; set; }
        // public Person OtherPerson { get; set; }
        // public int PersonId { get; set; }
        // public Group? Group { get; set; }
        // public int GroupId { get; set; }

        // methods
        public void Introduce() 
        {
            Console.WriteLine($"\nMy name is {Name},");
            if (Friendships.Count != 0) 
            {
                Console.WriteLine("My friends are");
                Friendships.ForEach(f => Console.WriteLine($"\t{f.OtherPerson.Name}"));
            } 
            else 
            {
                Console.WriteLine("I have no friends...");
            }
        }
        public void Befriend(Person p) 
        {
            var f = new Friendship(this, p);
            if (!Friendships.Contains(f))
                Friendships.Add(f);                
        }
        public void Unfriend(Person p) 
        {   
            var f = new Friendship(this, p);
            if (!Friendships.Contains(f))
                Friendships.Remove(f);
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

    public class Friendship 
    {
        public int Id { get; set; }

        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public int OtherPersonId {get; set; }

        public virtual Person OtherPerson { get; set; }

        public Friendship() 
        {
            
        }

        public Friendship(Person p1, Person p2)
        {
            Person = p1;
            OtherPerson = p2;
        }
    }
}