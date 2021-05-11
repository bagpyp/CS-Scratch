using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scratch 
{
    public class Group
    {
        // public int Id { get; set; }
        public List<Person> People { get; set; } = new();

        // [NotMapped]
        public int[,] Graph { get; set; } 

        // methods
        public int Count() 
        {
            return People.Count;
        }
        public void ListMembers() 
        {
            Console.WriteLine();
            People.ForEach(p => Console.WriteLine(p.Name));
        }
        public void Show()
        {
            ListMembers();
            Console.WriteLine();
            for (int i = 0; i < Count(); i++) 
            {
                for (int j = 0; j < Count(); j++) 
                {
                    if (i!=j)
                        Console.Write(Graph[i,j]);
                    else
                        Console.Write($"{(char)215}");
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
        public void AddPerson(Person p)
        {
            People.Add(p);
            var newGraph = new int[Count()+1,Count()+1];
            Graph = newGraph;
            RenderGraph();
        }
        public void RandomizeFriendships() 
        {
            var rand = new Random();
            for (int i = 0; i < Count(); i++) 
            {
                for (int j = i+1; j < Count(); j++) 
                {
                    var randInt = rand.Next(0,100);
                    // simulate a 30% friendship rate
                    if (randInt > 69 && randInt < 95)
                    {
                        Graph[i,j] = 1;
                        Graph[j,i] = 1;
                    }
                    // simulate a 5% non-reciprical friendship rate
                    else if (randInt > 94)
                    {
                        var randBit = rand.Next(0,2);
                        Graph[i,j] = randBit;
                        Graph[j,i] = randBit ^ 1;
                    }
                }
            }
            RenderPeople();
        }
        public void RenderGraph()
        {
            for (int i = 0; i < Count(); i++) 
            {
                for (int j = 0; j < Count(); j++) 
                {
                    
                    if (People[i].Friends.Contains(People[j]))
                    {
                        Graph[i,j] = 1;
                    }
                    else
                        Graph[i,j] = 0;
                }
            }
        }

        public void RenderPeople()
        {
            for (int i = 0; i < Count(); i++) 
            {
                for (int j = 0; j < Count(); j++) 
                {
                    if (i!=j && Graph[i,j] == 1) 
                        People[i].Befriend(People[j]);
                }
            }
        }
        // constructors
        public Group(string[] names)
        // Create a Group from a list of names where no friendships exist
        {
            int k = names.Length;
            foreach (string n in names) 
            {
            People.Add(new Person(n));
            }
            Graph = new int[k,k];
            for (int i = 0; i < k; i++) 
            {
                for (int j = 0; j < k; j++) 
                {
                    Graph[i,j] = 0;
                }
            }
        }   

        public Group(int[,] graph, string[] names)
        //  Create a Group from a list of names with friendship topology provided
        {   
            Graph = graph;
            foreach (string n in names) 
            {
            People.Add(new Person(n));
            }
            int k = names.Length;
            // use the graph to maCount()e friendships
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (graph[i,j] == 1)
                    {
                        People[i].Befriend(People[j]);
                    }
                }    
            }
        }   
        
        public Group(List<Person> people)
        // Create a group from a list of people, infer friendship topology
        {
            People = people;
            int k = people.Count;
            Graph = new int[k,k];
            for (int i = 0; i < k; i++) 
            {
                for (int j = 0; j < k; j++) 
                {
                    if (i!=j && people[i].Friends.Contains(people[j])) 
                        Graph[i,j] = 1;
                    else
                        Graph[i,j] = 0;
                }
            }
        } 

        // Helpers
        public static async Task<Group> GetGroupAsync(int groupSize)
        {
            using (var client = new HttpClient())
            {
                var uri = $"https://www.randomuser.me/api/?inc=name&results={groupSize}";
                var stringTask = client.GetStringAsync(uri);
                var stringResponse = await stringTask;
                Root response = JsonConvert.DeserializeObject<Root>(stringResponse);
                var people = new List<Person>(); 
                response.results.ForEach(
                    res => people.Add(new Person(res.name.ToFullName()))
                );
                return new Group(people);
            }
        }

        public class Name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }
            public string ToFullName() 
            {
                string output = first + " " + last;
                return output;
            }
        }

        public class Result
        {
            public Name name { get; set; }
        }

        public class Info
        {
            public string seed { get; set; }
            public int results { get; set; }
            public int page { get; set; }
            public string version { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
            public Info info { get; set; }
        }  
    }
}