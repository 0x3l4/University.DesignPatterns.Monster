using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DesignPatterns.Monster.Interfaces
{
    public interface IDamage
    {
        float PhysicalDamage { get; }
        float MagicDamage { get; }
    }
}
