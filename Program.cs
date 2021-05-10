using System.Threading.Tasks;

namespace Scratch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var groupTask = Group.GetGroupAsync(10);
            var group = await groupTask;
            group.RandomizeFriendships();
            group.Show();
            group.People.ForEach(p => p.Introduce());
        }
    }
}

