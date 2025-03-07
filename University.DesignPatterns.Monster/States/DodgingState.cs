using System.Threading;
using University.DesignPatterns.Monster.Entities;

namespace University.DesignPatterns.Monster.States
{
    public class DodgingState : EnemyState
    {
        private static Random _random = new Random();

        public DodgingState(Enemy monster) : base(monster)
        {
        }

        public override void Enter()
        {
            Console.WriteLine("Начинаю уклоняться...");
        }

        public override void Exit()
        {
            Console.WriteLine("Перестал уклоняться.");
        }

        public override void OnPlayerDetected()
        {
            throw new NotImplementedException();
        }

        public override void OnTakeDamage()
        {
            if (_enemy.Health.Points <= 30)
            {
                Console.WriteLine("Монстр тяжело ранен и переключается на поиск аптечки!");
                _enemy.ChangeState(new SearchingHealthState(_enemy));
            }
            else
            {
                Console.WriteLine("Монстр продолжает убегать...");
            }
        }

        public override void Update()
        {
            Console.WriteLine("Уклоняюсь...");
            //if (_enemy.Health.Points <= 20)
            //{
            //    _enemy.ChangeState(new SearchingHealthState(_enemy));
            //}
            //else if (_enemy.PlayerIsAttacking)
            //{
            //    if (_random.NextDouble() < 0.5)
            //    {
            //        Console.WriteLine($"{_enemy.Name} Уклонился от атаки!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{_enemy.Name} Получил урон!");
            //    }
            //    _enemy.PlayerIsAttacking = false;
            //}
            //else
            //{
            //    _enemy.ChangeState(new AttackingState(_enemy));
            //}
        }
    }
}
