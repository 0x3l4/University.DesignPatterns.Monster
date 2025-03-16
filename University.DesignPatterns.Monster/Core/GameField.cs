using University.DesignPatterns.Monster.Entities;

namespace University.DesignPatterns.Monster.Core
{
    public class GameField
    {
        private List<List<Cell>> _field;

        public List<Entity> Entities { get; private set; }
        public IEnumerable<IEnumerable<Cell>> Field => _field;
        public int Width => _field?.Count ?? -1;
        public int Height => _field?.ElementAt(0).Count ?? -1;

        public GameField(int width, int height)
        {
            if (width < 1 || height < 1)
            {
                throw new ArgumentException();
            }

            Entities = new List<Entity>();
           
            _field = new List<List<Cell>>(width);
            for (int i = 0; i < height; i++)
            {
                _field.Add(new List<Cell>(height));
                for (int j = 0; j < width; j++)
                {
                    _field[i].Add(Cell.None);
                }
            }
        }

        public void AddEntity(Entity entity)
        {
            if (!Entities.Contains(entity))
            {
                Entities.Add(entity);
                if (entity is Player)
                {
                    _field[entity.Y][entity.X] = Cell.Player;
                }
                else if (entity is Enemy) 
                {
                    _field[entity.Y][entity.X] = Cell.Enemy;
                }
            }
        }
    }
}