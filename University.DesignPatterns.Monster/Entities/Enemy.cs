using University.DesignPatterns.Monster.Core;
using University.DesignPatterns.Monster.Interfaces;
using University.DesignPatterns.Monster.Models;
using University.DesignPatterns.Monster.States;

namespace University.DesignPatterns.Monster.Entities
{
    public class Enemy : Entity, IAttackable, IDamagable, IMovable
    {
        public bool IsAlive { get; set; }
        public double MaxHealth { get; protected set; }
        public GameField Field { get; protected set; }
        public Damage Damage { get; protected set; }
        public Health Health { get; protected set; }
        public double TakedDamage { get; set; }

        private EnemyState _state;
        private int _visionRange;

        public Enemy(string name, Health health, Damage damage, GameField field, int x = 0, int y = 0) : base(name, x, y)
        {
            Health = health;
            MaxHealth = Health.Points;
            IsAlive = true;
            Damage = damage;
            Field = field;
            _state = new WanderingState(this);
            _visionRange = 1;
        }

        public void Update()
        {
            if (IsAlive)
            {
                _state.Update();
            }
        }

        public void Attack(IDamagable target)
        {
            if (IsAlive)
            {
                _state.Attack(target);
            }
        }

        public void TakeDamage(IDamage damage)
        {
            if (IsAlive)
            {
                _state.TakeDamage(damage);
            }
        }

        public string GetNameState()
        {
            return _state.Name;
        }

        public Player? SeesPlayer()
        {
            if (IsAlive)
            {
                Entity? entity = Field.Entities.Find(ent => ent is Player &&
                    (Math.Abs(X - ent.X) <= _visionRange &&
                    Math.Abs(Y - ent.Y) <= _visionRange));
                if (entity == null)
                    return null;

                return (Player)entity;
            }

            return null;
        }

        public void ChangeState(EnemyState state)
        {
            if (IsAlive)
            {
                _state.Exit();
                _state = state;
                _state.Enter();
            }
        }

        public void Move(int dx, int dy)
        {
            if (IsAlive)
            {
                if (X + dx < Field.Width - 1)
                {
                    X = Math.Max(X + dx, 0);
                }
                if (Y + dy < Field.Height - 1)
                {
                    Y = Math.Max(Y + dy, 0);
                }
            }
        }
    }
}
