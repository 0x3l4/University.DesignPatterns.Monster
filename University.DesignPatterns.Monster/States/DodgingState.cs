using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.States
{
    public class DodgingState : EnemyState
    {
        private readonly Random _random;
        private double _dodgeChance;

        public DodgingState(Enemy enemy) : base(enemy)
        {
            _dodgeChance = 0.3;
            _random = new Random();
            Name = "Уклоняться";
        }

        public override void Attack(IDamagable target) { }

        public override void Enter()
        {
            //Console.WriteLine("Начинаю уклоняться...");
        }

        public override void Exit()
        {
            //Console.WriteLine("Перестал уклоняться.");
        }

        public override void TakeDamage(IDamage damage)
        {
            if (_dodgeChance < _random.NextDouble())
            {
                double calculatedDamage = damage.PhysicalDamage + damage.MagicDamage;

                _enemy.TakedDamage += calculatedDamage;
            }
        }

        public override void Update()
        {
            if (_enemy.TakedDamage <= 0)
            {
                _enemy.ChangeState(new AttackingState(_enemy));
            }
            else
            {
                UpdateHealth();
            }

            if (_enemy.Health.Points <= 20)
            {
                _enemy.ChangeState(new HealthPackSearchingState(_enemy));
            }
        }

    }
}