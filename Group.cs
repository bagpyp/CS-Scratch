using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
        public void Show()
        {
            this.ListMembers();
            Console.WriteLine();
            int I = this.Graph.GetLength(0);
            int J = this.Graph.GetLength(1);
            for (int i = 0; i < I; i++) 
            {
                for (int j = 0; j < J; j++) 
                {
                    Console.Write(this.Graph[i,j]);
                    Console.Write(" ");
                }
                Console.Write("\n");
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
            this.Graph = new bool[k,k];
            for (int i = 0; i < k; i++) 
            {
                for (int j = 0; j < k; j++) 
                {
                    this.Graph[i,j] = false;
                }
            }
        }   
    }
}