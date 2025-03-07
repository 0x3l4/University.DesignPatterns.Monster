using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DesignPatterns.Monster.Interfaces;
using University.DesignPatterns.Monster.Models;
using University.DesignPatterns.Monster.States;

namespace University.DesignPatterns.Monster.Entities
{
    public class Enemy : Entity
    {
        private EnemyState _state;

        public Enemy(string name, Health health, Damage damage, int x = 0, int y = 0) :
            base(name, health, damage, x, y)
        {


            _state = new WanderingState(this);
            _state.Enter();
        }

        public void Update()
        {
            _state.Update();
        }

        public void ChangeState(EnemyState state)
        {
            _state.Exit();
            _state = state;
            _state.Enter();
        }

        public override void TakeDamage(IDamage damage)
        {
            
            base.TakeDamage(damage);
            _state.OnTakeDamage();
        }

        public bool SeePlayer()
        {
            return true;
        }

        public bool IsLowHealth()
        {
            return Health.Points <= 20;
        }
    }
}
