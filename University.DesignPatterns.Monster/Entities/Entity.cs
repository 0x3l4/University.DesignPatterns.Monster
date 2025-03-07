using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Monster.Core;
using University.DesignPatterns.Monster.Interfaces;
using University.DesignPatterns.Monster.Models;

namespace University.DesignPatterns.Monster.Entities
{
    public class Entity : IMovable, IAttackable, IDamagable
    {
        public GameField Field { get; protected set; }
        public Health Health { get; protected set; }
        public Damage Damage { get; protected set; }

        public string Name { get; protected set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public bool IsAlive { get; protected set; }

        public Entity(string name, Health health, Damage damage, int x = 0, int y = 0)
        {
            Name = name;
            Health = health;
            Damage = damage;
            X = x;
            Y = y;
        }


        public virtual void Move(int dx, int dy)
        {
            Console.WriteLine($"Перемещение {Name}: dx: {dx}, dy: {dy}");
        }

        public virtual void Attack(IDamagable target)
        {
            Console.WriteLine($"{Name} атакует!");
            target.TakeDamage(Damage);
        }

        public virtual void TakeDamage(IDamage damage)
        {
            if (IsAlive)
            {
                float points = Health.Points - Damage.PhysicalDamage + Damage.MagicDamage;
                Console.WriteLine($"{Name} получает {points} урона!");
                Health.Points = Math.Max(points, 0);

                if (Health.Points == 0)
                {
                    Console.WriteLine($"{Name} погиб!");
                    IsAlive = false;
                }
            }
        }
    }
}
