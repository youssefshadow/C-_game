using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    internal class DefensiveMidFielder : Midfielder, I_PincerDefense
    {
        public DefensiveMidFielder(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        private Player player;

        public Player Helper { get => player; set => player = value; }
    }
}
