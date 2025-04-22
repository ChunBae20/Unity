using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This_is_Sparta__
{
    class Enemy
    {
        public int Level { get;}
        public string Name { get;}
        public int Atk { get;}
        public int MaxHp { get;}
        public int CurrentHp { get; set; }
        public bool IsDead { get; set; } = false;

        public Enemy(string name, int level,  int atk, int maxHp)
        {
            Name = name;
            Level = level;
            Atk = atk;
            MaxHp = maxHp;
            CurrentHp = maxHp;
            
        }
        public string EnemyInfoText()
        {
            string status = IsDead ? "Dead" : $"HP {CurrentHp}";
            return $"Lv.{Level} {Name} {status}";
        }


    }

}
