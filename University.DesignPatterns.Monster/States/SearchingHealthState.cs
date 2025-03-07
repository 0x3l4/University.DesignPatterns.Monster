using University.DesignPatterns.Monster.Entities;

namespace University.DesignPatterns.Monster.States
{
    public class SearchingHealthState : EnemyState
    {
        public SearchingHealthState(Enemy monster) : base(monster)
        {
        }

        public override void Enter()
        {
            Console.WriteLine("Начинаю искать аптечку...");
        }

        public override void Exit()
        {
            Console.WriteLine("Перестал искать аптечку.");
        }

        public override void OnPlayerDetected()
        {
            throw new NotImplementedException();
        }

        public override void OnTakeDamage()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            Console.WriteLine("Ищу аптечку.");
        }

        private void Heal(Enemy enemy)
        {
            enemy.Health.Points += 50; // Симуляция нахождения аптечки
            Console.WriteLine($"Монстр нашел аптечку и восстановил здоровье! Текущее здоровье: {enemy.Health.Points}");

            if (enemy.Health.Points >= 100)
            {
                Console.WriteLine("Монстр полностью здоров, возвращается к патрулированию.");
                enemy.ChangeState(new WanderingState(enemy));
            }
        }
    }
}
