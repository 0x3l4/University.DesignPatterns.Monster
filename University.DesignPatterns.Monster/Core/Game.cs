using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Models;

namespace University.DesignPatterns.Monster.Core
{
    public class Game
    {
        private Player _player;
        private Enemy _enemy;


        public bool IsRunning { get; private set; }

        public Game()
        {
            IsRunning = false;
        }

        public async Task Run()
        {
            IsRunning = true;

            Initialize();

            while (IsRunning)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            _player.Move(0, -1);
                            break;
                        case ConsoleKey.S:
                            _player.Move(0, 1);
                            break;
                        case ConsoleKey.A:
                            _player.Move(-1, 0);
                            break;
                        case ConsoleKey.D:
                            _player.Move(1, 0);
                            break;
                    }

                    Update();
                }
            }
        }

        private void Update()
        {

        }

        private void Initialize()
        {
            //_player = new Player();
            _enemy = new Enemy("Монстр", new Health(100), new Damage(10, 5));
        }
    }
}
