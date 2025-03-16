using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.States
{
    public class WanderingState : EnemyState
    {
        private static Random _random;

        static WanderingState()
        {
            _random = new Random();
        }

        public WanderingState(Enemy enemy) : base(enemy)
        {
            Name = "Бродить";
        }

        public override void Attack(IDamagable target) { }

        public override void Enter()
        {
            //Console.WriteLine("Начинаю бродить...");
        }

        public override void Exit()
        {
            //Console.WriteLine("Прекратил бродить.");
        }

        public override void TakeDamage(IDamage damage)
        {
            double calculatedDamage = damage.PhysicalDamage + damage.MagicDamage;

            _enemy.TakedDamage += calculatedDamage;
        }

        public override void Update()
        {
            UpdateHealth();

            Player? nearestPlayer = _enemy.SeesPlayer();

            if (nearestPlayer != null)
            {
                _enemy.ChangeState(new AttackingState(_enemy));
                _enemy.Update();
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
