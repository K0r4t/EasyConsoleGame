using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    public interface IEnemy
    {
        public void Spawn(int hor, int vert);
        public void Respawn();
        public bool TakeDamage(int power);
        public void EnemyMove();
    }
}
