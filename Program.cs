using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Scratch
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var factory = new ScratchContextFactory();
            using var context = factory.CreateDbContext(args);
            
            context.Persons.RemoveRange(context.Persons);
            context.Friendships.RemoveRange(context.Friendships);
            
            int k;
            if (args.Length > 0)
                k = Int32.Parse(args[0]);
            else
                k = 3;
            var groupTask = Group.GetGroupAsync(k);
            var group = await groupTask;

            group.RandomizeFriendships();
            
            foreach (Person p in group.People) 
            {
                await context.AddAsync(p);
            }
            await context.SaveChangesAsync();

            group.Show();

            foreach (Person p in context.Persons.OrderBy(p => p.Id)) 
            {
                p.Introduce();
            }
        }
    }
}

