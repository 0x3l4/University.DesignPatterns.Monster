using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Monster.Entities;

namespace University.DesignPatterns.Monster.States
{
    public class WanderingState : EnemyState
    {
        private static Random _random = new Random();

        public WanderingState(Enemy monster) : base(monster)
        {
        }

        public override void Enter()
        {
            Console.WriteLine("Начинаю бродить...");
        }

        public override void Exit()
        {
            Console.WriteLine("Перестал бродить.");
        }

        public override void OnPlayerDetected()
        {
            throw new NotImplementedException();
        }

        public override void OnTakeDamage()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            Console.WriteLine("Брожу...");
            //if (_enemy.PlayerInSight)
            //{
            //    Console.WriteLine($"{_enemy.Name}: Игрок в зоне видимости!");
            //    _enemy.ChangeState(new AttackingState(_enemy));
            //    _enemy.PlayerInSight = false;
            //}
            //else
            //{
            //    _enemy.Move(_random.Next(-1, 2), _random.Next(-1, 2));
            //}

        }
    }
}
