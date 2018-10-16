using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    public class Roll
    {
        public Roll(string rollInput)
        {
            RollInput = rollInput;
            var diceParams = RollInput.Trim().Split(" ");

            foreach (var param in diceParams)
            {
                switch (param)
                {
                    case "SUM":
                        HasSum = true;
                        break;
                    case "ADV":
                        HasAdvantage = true;
                        break;
                    case "DIS":
                        HasDisadvantage = true;
                        break;
                    default:
                        //Add all the Die with the correct number of sides
                        //XdY => where X= number of dice to roll and Y= number of sides on each die
                        var dieParams = diceParams[0].Split("D");
                        Dice = new List<Models.Die>();

                        for (int i = 1; i <= Convert.ToInt32(dieParams[0]); i++)
                        {
                            Models.Die newDie = new Models.Die(i, Convert.ToInt16(dieParams[1]));
                            Dice.Add(newDie);
                        }
                        break;
                }
            }
        }

        public List<Die> Dice { get; }

        public bool HasAdvantage { get; }

        public bool HasDisadvantage { get; }

        public bool HasSum { get; }

        public string RollInput { get; }

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
