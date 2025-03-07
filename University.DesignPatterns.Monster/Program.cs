using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Models;

namespace University.DesignPatterns.Monster
{
    internal class Program
    {
        public static async Task Main()
        {
            //Game game = new Game();
            //await game.Run();

            Enemy enemy = new Enemy("Monster", new Health(100), new Damage(10, 3));
            Player player = new Player("Player", new Health(100), new Damage(10, 3));

            enemy.Update();
            enemy.Update();
        }
    }
}



