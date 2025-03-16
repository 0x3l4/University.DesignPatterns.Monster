using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.States
{
    public class HealthPackSearchingState : EnemyState
    {
        private static Random _random;
        private static double _healthChance;

        static HealthPackSearchingState()
        {
            _random = new Random();
            _healthChance = 0.5;
        }

        public HealthPackSearchingState(Enemy enemy) : base(enemy)
        {
            Name = "Искать аптечку";
        }

        public override void Attack(IDamagable target) { }

        public override void Enter()
        {
            //Console.WriteLine("Начинаю искать аптечку...");
        }

        public override void Exit()
        {
            //Console.WriteLine("Перестал искать аптечку.");
        }

        public override void TakeDamage(IDamage damage)
        {
            double calculatedDamage = damage.PhysicalDamage + damage.MagicDamage;

            _enemy.TakedDamage += calculatedDamage;
        }

        public override void Update()
        {
            UpdateHealth();

            if (_enemy.IsAlive)
            {
                if (_random.NextDouble() < _healthChance)
                {
                    _enemy.Health.Points += 50;
                    _enemy.ChangeState(new WanderingState(_enemy));
                }
                else
                {
                    bool moveX = _random.Next(0, 2) == 0;
                    int delta = _random.Next(0, 2) == 0 ? -1 : 1;

                    if (moveX)
                    {
                        _enemy.Move(delta, 0);
                    }
                    else
                    {
                        _enemy.Move(0, delta);
                    }
                }
            }
        }
    }
}
