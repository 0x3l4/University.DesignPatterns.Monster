namespace University.DesignPatterns.Monster.Entities
{
    public class Entity
    {
        public string Name { get; protected set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Entity(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
