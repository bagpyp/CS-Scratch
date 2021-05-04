using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Runtime.Serialization;

namespace Scratch
{    class Program
    {
        static void Main(string[] args)
        {
            var robbie = new Person("Robbie");
            var heather = new Person("Heather");
            var corey = new Person("Corey");
            Person.CreateFriendship(robbie, heather);
            foreach (Person p in new List<Person> { robbie, heather })
            {
                corey.Befriend(p);
                p.Befriend(corey);
            }
            var stranger = new Person();
            stranger.Befriend(corey);
            
            var people = new List<Person>() {robbie, heather, corey, stranger};
            var group = new Group(people);

            group.Show();

            Console.WriteLine();
            foreach (Person p in people)
            {
                p.Introduce();
            }
        }
    }
}
