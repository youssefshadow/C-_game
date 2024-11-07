using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    public class OffensiveMidfielder : Midfielder, I_Opportunist
    {
        public OffensiveMidfielder(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }
    }
}
