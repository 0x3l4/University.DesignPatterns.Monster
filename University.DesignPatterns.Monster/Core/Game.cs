using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Models;

namespace University.DesignPatterns.Monster.Core
{
    public class Game
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public bool IsRunning { get; private set; }
        public GameField Field { get; private set; }


        public void Run()
        {
            IsRunning = true;

            Initialize();

            Console.WriteLine("Управление:");
            Console.WriteLine("Передвижение: WASD");
            Console.WriteLine("Атака: F");
            Console.WriteLine("Нажмите для начала игры!");
            Console.ReadLine();
            Console.CursorVisible = false;
            GameRenderer.Render(this);
            while (IsRunning)
            {
                ConsoleKey input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.W:
                        if (Player.Y > 0)
                            Player.Move(0, -1);
                        break;
                    case ConsoleKey.A:
                        if (Player.X > 0)
                            Player.Move(-1, 0);
                        break;
                    case ConsoleKey.S:
                        if (Player.Y < Field.Height - 1)
                            Player.Move(0, 1);
                        break;
                    case ConsoleKey.D:
                        if (Player.X < Field.Width - 1)
                            Player.Move(1, 0);
                        break;
                    case ConsoleKey.F:
                        Player.Attack(Enemy);
                        break;
                    default:
                        break;
                }

                Enemy.Update();

                GameRenderer.Render(this);
            }
        }

        private void Initialize()
        {
            Player = new Player("player123", new Health(9999), new Damage(10, 5), 2, 2);
            Field = new GameField(11, 18);
            Enemy = new Enemy("Монстр", new Health(100), new Damage(10, 5), Field, 8, 8);
            Field.AddEntity(Player);
            Field.AddEntity(Enemy);
        }
    }
}
