using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    public class Roll
    {
        public List<Die> Dice { get; set; }

        public bool HasAdvantage { get; set; }

        public bool HasDisadvantage { get; set; }

        public bool HasSum { get; set; }

        public string RollInput { get; set; }

        /// <summary>
        /// If the roll had advantage, then need to drop the lowest number
        /// If it has disadvantage, then drop the heighest
        /// </summary>
        public void SetAdvantages ()
        {
            if (HasAdvantage || HasDisadvantage)
            {
                //Don't reorder the original list....
                var orderedDice = Dice.OrderBy(die => die.Result);
                int dieNumber = HasAdvantage ? orderedDice.First().DieNumber : orderedDice.Last().DieNumber;
                Dice.Where(x => x.DieNumber.Equals(dieNumber)).FirstOrDefault().ResultDropped = true;
            }
            else
            {
                //Do nothing
            }
        }

        public int SumOfRoll
        {
            get
            {
                var total = Dice.Where(x => x.Result > 0 && !x.ResultDropped).Sum(x => x.Result);
                return total;
            }
        }
    }
}
