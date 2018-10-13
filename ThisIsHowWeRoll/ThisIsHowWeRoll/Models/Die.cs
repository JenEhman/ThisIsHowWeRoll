using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    [Serializable]
    public class Die
    {
        public int NumberOfSides { get; set; }

        public int Result { get; private set; }

        public bool ResultDropped { get; set; }

        public void RoleDie()
        {
            var dieRollResult = new Random(0);
            Result = dieRollResult.Next(NumberOfSides + 1);
        }
    }
}
