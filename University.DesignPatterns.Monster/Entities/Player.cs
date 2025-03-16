using University.DesignPatterns.Monster.Interfaces;
using University.DesignPatterns.Monster.Models;

namespace University.DesignPatterns.Monster.Entities
{
    public class Player : Entity, IAttackable, IDamagable, IMovable
    {
        public double MaxHealth { get; protected set; }
        public Health Health { get; set; }
        public Damage Damage { get; set; }

        public Player(string name, Health health, Damage damage, int x, int y) : base(name, x, y)
        {
            Health = health;
            MaxHealth = Health.Points;
            Damage = damage;
        }

        public void Attack(IDamagable target)
        {
            target.TakeDamage(Damage);
        }

        public void TakeDamage(IDamage damage)
        {
            double calculatedDamage = damage.PhysicalDamage + damage.MagicDamage;
            Health.Points -= calculatedDamage;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}
