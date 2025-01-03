using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsChampion
{
    internal class Player
    {
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Health { get; set; }
        public int Agility { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }

        public Player(int id,string name) {
            Random rnd = new Random();
            Attack = rnd.Next(6,11);
            Defence = rnd.Next(6, 11);
            Agility = rnd.Next(6, 11);
            Health = 10;
            Name = name;
            ID = id;
        }
    }
}
//    利用類別生成4個人, 其素值包含攻擊/防禦/敏捷/血
//    血固定為10,
//    攻擊/防禦/敏捷以亂數產生, 值為6~10