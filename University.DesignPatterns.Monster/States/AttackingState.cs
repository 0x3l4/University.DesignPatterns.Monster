using University.DesignPatterns.Monster.Entities;

namespace University.DesignPatterns.Monster.States
{
    public class AttackingState : EnemyState
    {
        public AttackingState(Enemy enemy) : base(enemy)
        {

        }

        public override void Enter()
        {
            Console.WriteLine("Начинаю атаковать...");
        }

        public override void Exit()
        {
            Console.WriteLine("Перестал атаковать.");
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
            //if (_enemy.PlayerIsAttacking)
            //{
            //    _enemy.ChangeState(new DodgingState(_enemy));
            //    _enemy.PlayerIsAttacking = false;
            //}
            //else if (_enemy.PlayerInSight)
            //{
            //    Console.WriteLine("Атакую...");
            //    _enemy.PlayerInSight = false;
            //}
            //else
            //{
            //    _enemy.ChangeState(new WanderingState(_enemy));
            //}

        }
    }
}
