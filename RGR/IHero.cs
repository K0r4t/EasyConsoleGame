using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR
{
    public interface IHero
    {
        public void Spawn();
        public void Movedown();
        public void Moveright();
        public void Moveleft();
        public void Moveup();
        public void HeroShow();
        public void AddGold();
        public void AddHP();
        public void AddPower();

    }
}
