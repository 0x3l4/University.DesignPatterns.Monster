using University.DesignPatterns.Monster.Entities;
using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.States
{
    public abstract class EnemyState : IAttackable, IDamagable
    {
        public string Name { get; protected set; }

        protected Enemy _enemy;

        public EnemyState(Enemy enemy)
        {
            _enemy = enemy;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();

        public abstract void Attack(IDamagable target);

        public abstract void TakeDamage(IDamage damage);

        protected void UpdateHealth()
        {
            if (_enemy.TakedDamage > 0)
            {
                _enemy.Health.Points = Math.Max(_enemy.Health.Points - _enemy.TakedDamage, 0);

                if (_enemy.Health.Points == 0)
                {
                    _enemy.IsAlive = false;
                }

                _enemy.TakedDamage = 0;
            }
        }
    }
}