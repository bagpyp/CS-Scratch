using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int k;
            if (args.Length > 0)
                k = Int32.Parse(args[0]);
            else
                k = 3;
            var groupTask = Group.GetGroupAsync(k);
            var group = await groupTask;
            group.RandomizeFriendships();
            group.Show();            
        }
    }
}

