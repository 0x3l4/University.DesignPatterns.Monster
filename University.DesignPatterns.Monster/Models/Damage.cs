using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.Models
{
    public class Damage : IDamage
    {
        public double PhysicalDamage { get; protected set; }
        public double MagicDamage { get; protected set; }

        public Damage(double physicalDamage, double magicDamage)
        {
            PhysicalDamage = physicalDamage;
            MagicDamage = magicDamage;
        }
    }
}
