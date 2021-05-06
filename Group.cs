using System;
using System.Collections.Generic;

namespace Scratch 
{
    public class Group
    {
        public List<Person> People { get; set; }
        public int[,] Graph { get; set; } 
        // methods
        public void ListMembers() 
        {
            Console.WriteLine();
            this.People.ForEach(p => Console.WriteLine(p.Name));
        }
        public int Size() 
        {
            if (this.People == null)
                return 0;
            else
                return this.People.Count;
        }
        public void Show()
        {
            this.ListMembers();
            Console.WriteLine();
            int k = this.Size();
            for (int i = 0; i < k; i++) 
            {
                for (int j = 0; j < k; j++) 
                {
                    Console.Write(this.Graph[i,j]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
        public void AddPerson(Person p)
        {
            int k = this.Size();
            this.People.Add(p);
            var newGraph = new int[k+1,k+1];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    newGraph[i,j] = this.Graph[i,j];
                }
                newGraph[i,k] = 0;  
                newGraph[k,i] = 0;  
            }
            this.Graph = newGraph;
            this.RenderGraph();
        }
        public void RenderGraph()
        {
            int k = this.Size();
            for (int i = 0; i < k; i++) 
            {
                for (int j = 0; j < k; j++) 
                {
                    if (this.People[i].Friends != null && this.People[i].Friends.Contains(this.People[j])) 
                        this.Graph[i,j] = 1;
                    else
                        this.Graph[i,j] = 0;
                }
            }
        }

        // constructors
        public Group(params string[] names)
        {
            int k = names.Length;
            foreach (string n in names) 
            {
            if (this.People == null)
                this.People = new List<Person> {new Person(n)};
            else 
                this.People.Add(new Person(n));
            }
            this.Graph = new int[k,k];
            for (int i = 0; i < k; i++) 
            {
                for (int j = 0; j < k; j++) 
                {
                    this.Graph[i,j] = 0;
                }
            }
        }   

        public Group(int[,] graph, List<String> names)
        {   
            this.Graph = graph;
            // create the people from the list of names
            foreach (string n in names) 
            {
            if (this.People == null)
                this.People = new List<Person> {new Person(n)};
            else 
                this.People.Add(new Person(n));
            }
            int k = names.Count;
            // use the graph to make friendships
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (graph[i,j] == 1)
                    {
                        this.People[i].Befriend(this.People[j]);
                    }
                }    
            }
        }   
        
        public Group(List<Person> people)
        {
            this.People = people;
            int k = people.Count;
            this.Graph = new int[k,k];
            for (int i = 0; i < k; i++) 
            {
                for (int j = 0; j < k; j++) 
                {
                    if (people[i].Friends != null && people[i].Friends.Contains(people[j])) 
                        this.Graph[i,j] = 1;
                    else
                        this.Graph[i,j] = 0;
                }
            }
        }   
    }
}