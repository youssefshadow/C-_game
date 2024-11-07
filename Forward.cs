using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    public class Forward : Player
    {
        public Forward(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {

        }

        protected override void ShowReceptionResult(int reception, int receptionDifficulty)
        {
            MyLog($"{Name} est un attaquant la difficulté de reception est divisée par 2");
            base.ShowReceptionResult(reception, receptionDifficulty/2);
        }

        protected override void MyLog(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.MyLog(value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
