using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    public class Midfielder : Player
    {
        public Midfielder(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        protected override (int interceptionDifficulty, int receptionDifficulty) CalculatePassScores()
        {
            MyLog($"{Name} est un milieu de terrain. Précision + 10 et difficulté de reception - 50");
            int interceptionDifficulty = Agility + Reflexs + GetLuck() +10;
            int receptionDifficulty = 150 - (Agility + Strength + GetLuck());
            return (interceptionDifficulty, receptionDifficulty);
        }

        protected override void MyLog(string value)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.MyLog(value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
