using System;
using System.Collections.Generic;

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
            corey.Unfriend(heather);
            var people = new List<Person>() {robbie, heather, corey, stranger};
            var group = new Group(people);

            group.Show();

            foreach (Person p in people)
            {
                p.Introduce();
            };
            
            var graph = new int[3,3] 
            {
                {0,1,1},
                {1,0,0},
                {1,1,0}
            };
            var names = new List<String> {"Gavin", "Scott", "Robbie"};
            var group2 = new Group(graph, names);

            group2.Show();
            foreach (Person p in group2.People)
            {
                p.Introduce();
            };

            var savannah = new Person("Savannah");
            group2.AddPerson(savannah);
            group2.Show();

            corey.Befriend(savannah);
            group2.AddPerson(corey);
            group2.Show();
        }
    }
}
