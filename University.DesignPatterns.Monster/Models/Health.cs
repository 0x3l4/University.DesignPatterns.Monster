using University.DesignPatterns.Monster.Interfaces;

namespace University.DesignPatterns.Monster.Models
{
    public class Health : IHealth
    {
        public float Points { get; set; }

        public Health(float points)
        {
            Points = points;
        }
    }
}
