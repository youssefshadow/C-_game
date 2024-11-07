using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPI_FootHeritage_2024_2025
{
    public interface I_PincerDefense
    {
        string Name { get; }
        Player Helper { get; set; }

        public int HelpValue(Action<string> MyLog)
        {
            if (Helper == null) 
            {
                MyLog($"{Name} n'est aidé par personne");
                return 0;
            }

            int result = (Helper.Agility + Helper.Speed) / 2;
            MyLog($"{Name} est aidé par {Helper.Name} et son tacle est amélioré de {result}.");
            return result;
        }


    }
}
