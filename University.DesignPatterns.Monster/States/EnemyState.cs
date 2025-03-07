using University.DesignPatterns.Monster.Entities;

namespace University.DesignPatterns.Monster.States
{
    public abstract class EnemyState
    {
        protected Enemy _enemy;

        public EnemyState(Enemy enemy)
        {
            _enemy = enemy;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
        public abstract void OnPlayerDetected();
        public abstract void OnTakeDamage();
    }
}
