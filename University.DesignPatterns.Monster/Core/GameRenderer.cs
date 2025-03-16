namespace University.DesignPatterns.Monster.Core
{
    public static class GameRenderer
    {
        public static void Render(Game game)
        {
            Console.SetCursorPosition(0, 0);
            //Console.Clear();
            ClearRow();
            for (int i = 0; i < game.Field.Width + 2; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();

            for (int i = 0; i < game.Field.Height; i++)
            {
                ClearRow();
                Console.Write("#");
                for (int j = 0; j < game.Field.Width; j++)
                {
                    Console.Write('.');
                }
                Console.WriteLine("#");
            }

            for (int i = 0; i < game.Field.Width + 2; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();

            ClearRow();
            Console.WriteLine($"{game.Enemy.Name}: {game.Enemy.GetNameState()}");
            ClearRow();
            Console.Write("HP: ");
            DrawHealthBar(game.Enemy.Health.Points, game.Enemy.MaxHealth);
            ClearRow();
            Console.WriteLine($"{game.Player.Name}");
            ClearRow();
            Console.Write("HP: ");
            DrawHealthBar(game.Player.Health.Points, game.Player.MaxHealth);

            (int left, int top) = Console.GetCursorPosition();

            if (game.Enemy.X >= 0 && game.Enemy.Y >= 0)
            {
                Console.SetCursorPosition(game.Enemy.X + 1, game.Enemy.Y + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                if (game.Enemy.IsAlive)
                {
                    Console.Write('E');
                }
                else
                {
                    Console.Write('X');
                }
                Console.ResetColor();
            }

            if (game.Player.X >= 0 && game.Player.Y >= 0)
            {
                Console.SetCursorPosition(game.Player.X + 1, game.Player.Y + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write('P');
                Console.ResetColor();
            }

            Console.SetCursorPosition(left, top);
        }

        private static void DrawHealthBar(double health, double maxHealth)
        {
            int barLength = 10;
            int filledBars = (int)Math.Round(health / maxHealth * barLength);

            Console.Write("[");
            for (int i = 0; i < barLength; i++)
            {
                if (i < filledBars)
                    Console.Write("#");
                else
                    Console.Write("-");
            }
            Console.WriteLine($"] {health}/{maxHealth}");
        }

        private static void ClearRow()
        {
            Console.Write($"\r" + new string(' ', Console.BufferWidth) + "\r");
        }
    }
}
