using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    public class Defender : Player
    {
        public Defender(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        protected override int CalculateTackleScore()
        {
            int baseValue = base.CalculateTackleScore();
            MyLog($"{Name} fait un tackle glissé. il ajoute son agilité à son score de tacle. {baseValue} -> {baseValue+Agility}");
            return baseValue + Agility;
        }

        protected override void MyLog(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            base.MyLog(value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
