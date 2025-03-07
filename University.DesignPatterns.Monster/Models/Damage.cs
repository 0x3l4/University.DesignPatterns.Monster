using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.Models
{
    public class Damage : IDamage
    {
        public float PhysicalDamage { get; protected set; }

        public float MagicDamage { get; protected set; }

        public Damage(float physical, float magic)
        {
            PhysicalDamage = physical;
            MagicDamage = magic;
        }
    }
}
