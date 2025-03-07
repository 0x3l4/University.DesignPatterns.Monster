using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Monster.Models;

namespace University.DesignPatterns.Monster.Entities
{
    public class Player : Entity
    {
        public Player(string name, Health health, Damage damage, int x = 0, int y = 0) :
            base(name, health, damage, x, y)
        {
        }
    }
}
