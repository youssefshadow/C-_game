using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    public class Goalkeeper : Player
    {
        public Goalkeeper(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50) : base(name, speed, agility, strength, reflexs, luck)
        {
        }

        public void StopShoot(int shootScore)
        {
            int stopScore = CalculateStopScore();
            MyLog($"{Name} essaye d'arrêter le tir. StopScore {stopScore}");
            if (stopScore >= shootScore)
            {
                MyLog($"{Name} réussi son arrêt. StopScore {stopScore} >= ShootScore {shootScore}");
            }
            else
            {
                MyLog($"{Name} rate son arrêt. StopScore {stopScore} < ShootScore {shootScore}");
                Console.WriteLine("GOALLLLLLLL!");
            }
        }

        protected int CalculateStopScore()
        {
            return Reflexs + Agility + GetLuck();
        }

        protected override void MyLog(string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            base.MyLog(value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
