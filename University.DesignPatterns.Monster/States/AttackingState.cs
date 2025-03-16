using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.States
{
    public class AttackingState : EnemyState
    {
        public AttackingState(Enemy enemy) : base(enemy)
        {
            Name = "Атаковать";
        }

        public override void Attack(IDamagable target)
        {
            target.TakeDamage(_enemy.Damage);
        }

        public override void Enter()
        {
            //Console.WriteLine("Начинаю атаковать...");
        }

        public override void Exit()
        {
            //Console.WriteLine("Перестал атаковать...");
        }

        public override void TakeDamage(IDamage damage)
        {
            _enemy.ChangeState(new DodgingState(_enemy));
            _enemy.TakeDamage(damage);
        }

        public override void Update()
        {
            Player? nearestPlayer = _enemy.SeesPlayer();

            if (nearestPlayer != null)
            {
                _enemy.Attack(nearestPlayer);
            }
            else
            {
                _enemy.ChangeState(new WanderingState(_enemy));
            }
        }
    }
}
