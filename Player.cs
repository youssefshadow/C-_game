using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    public class Player
    {
        public string Name { get; private set; }
        public int Speed { get; private set; }
        public int Agility { get; private set; }
        public int Strength { get; private set; }
        public int Reflexs { get; private set; }
        public int Luck { get; private set; }

        private Random random;

        public Player(string name, int speed = 50, int agility = 50, int strength = 50, int reflexs = 50, int luck = 50)
        {
            Name = name;
            Speed = speed;
            Agility = agility;
            Strength = strength;
            Reflexs = reflexs;
            Luck = luck;
            random = new Random(GetSeed());
        }

        public virtual void Pass(Player target, List<Player> opponents)
        {
            (int interceptionDifficulty, int receptionDifficulty) result = CalculatePassScores();
            MyLog($"{Name} fait une passe a {target.Name}. Precision {result.interceptionDifficulty} | difficulté de reception {result.receptionDifficulty}");
            if (TryToIntercept(result.interceptionDifficulty, opponents))
            {
                return;
            }

            //reception
            target.ReceiptPass(result.receptionDifficulty);
        }

        protected virtual (int interceptionDifficulty, int receptionDifficulty) CalculatePassScores()
        {
            int interceptionDifficulty = Agility + Reflexs + GetLuck();
            int receptionDifficulty = 200 - (Agility + Strength + GetLuck());

            return (interceptionDifficulty, receptionDifficulty);
        }

        public virtual void ReceiptPass(int receptionDifficulty)
        {
            int reception = CalculateReceptionScore();
            ShowReceptionResult(reception, receptionDifficulty);
        }

        protected virtual int CalculateReceptionScore()
        {
            return Agility + Reflexs + GetLuck();
        }

        protected virtual void ShowReceptionResult(int reception, int receptionDifficulty)
        {
            if (reception > receptionDifficulty)
            {
                MyLog($"{Name} receptionne la passe. Reception {reception} > difficulté de reception {receptionDifficulty}");
            }
            else
            {
                MyLog($"{Name} manque sa réception. Reception {reception} < difficulté de reception {reception}");
            }
        }

        protected virtual void MyLog(string value)
        {
            Console.WriteLine(value);
        }

        public bool Intercept(int interceptionDifficulty)
        {
            int interceptScore = CalculateInterceptScore();
            if (interceptScore >= interceptionDifficulty)
            {
                MyLog($"{Name} intercepte le ballon. interceptScore {interceptScore} >= interceptiondifficulty {interceptionDifficulty}");
                return true;
            }
            else
            {
                MyLog($"{Name} rate son interception. interceptScore {interceptScore} < interceptiondifficulty {interceptionDifficulty}");
                return false;
            }
        }

        protected int CalculateInterceptScore()
        {
            return Agility + Reflexs + GetLuck();
        }

        public void Shoot(List<Player> opponents, Goalkeeper goalkeeper)
        {
            int shootScore = CalculateShootScore();
            MyLog($"{Name} tire. Shootscore {shootScore}");
            if (TryToIntercept(shootScore, opponents))
            {
                return;
            }

            goalkeeper.StopShoot(shootScore);
        }

        public bool TryToIntercept(int shootScore, List<Player> opponents)
        {
            bool interception = false;
            foreach (Player opponent in opponents)
            {
                interception = opponent.Intercept(shootScore);
                if (interception)
                {
                    return true;
                }
            }
            return false;
        }

        protected int CalculateShootScore()
        {
            return Strength + Speed + GetLuck();
        }

        public void Tackle(int dribbleScore, Player opponent)
        {
            int tackleScore = CalculateTackleScore();
            MyLog($"{Name} tackle {opponent.Name}. TacleScore {tackleScore}");
            if (tackleScore >= dribbleScore)
            {
                MyLog($"{Name} récupère le ballon avec son tacle. Tacle score {tackleScore} >= dribble score {dribbleScore}");
            }
            else
            {
                MyLog($"{Name} ne réussi pas son tacle. Tacle score {tackleScore} < dribble score {dribbleScore}");
            }
        }

        protected virtual int CalculateTackleScore()
        {
            return Strength + Speed + GetLuck();
        }

        public void Dribble(Player opponent)
        {
            int dribbleScore = CalculateDribbleScore();
            MyLog($"{Name} tente de dribbler {opponent.Name}. DribbleScore {dribbleScore}");
            opponent.Tackle(dribbleScore, this);
        }

        protected int CalculateDribbleScore()
        {
            return  Agility + Speed + GetLuck();
        }

        public int GetLuck()
        {
            return random.Next(Luck);
        }

        private int GetSeed()
        {
            int result = 0;
            int index = 1;
            foreach (char c in Name)
            {
                result += ((int)c) * index;
                index++;
            }

            return result;
        }
    }
}
