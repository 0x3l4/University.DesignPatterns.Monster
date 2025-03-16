using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.Models
{
    public class Health : IHealth
    {
        public double Points { get; set; }

        public Health(double points)
        {
            Points = points;
        }
    }
}
