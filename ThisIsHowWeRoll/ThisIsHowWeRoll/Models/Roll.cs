using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    [Serializable]
    public class Roll
    {
        public List<Die> Dice { get; set; }

        public bool HasSum { get; set; }

        public int SumOfRoll
        {
            get
            {
                var total = Dice.Where(x => x.Result > 0 && !x.ResultDropped).Sum(x => x.Result);
                return total;
            }
        }

        public bool HasAdvantage { get; set; }

        public bool HasDisadvantage { get; set; }
    }
}
