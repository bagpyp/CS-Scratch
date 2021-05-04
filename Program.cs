using System;
using System.Collections.Generic;

namespace Scratch
{    class Program
    {
        static void Main(string[] args)
        {
            var robbie = new Person("Robbie");
            var heather = new Person("Heather");
            Person.CreateFriendship(robbie, heather);
            heather.Unfriend(robbie);
            var corey = new Person("Corey");
            foreach (Person p in new List<Person> {robbie, heather}) 
            {
                p.Befriend(corey);
                p.Introduce();
            }
            corey.Introduce();
        }
    }
}
