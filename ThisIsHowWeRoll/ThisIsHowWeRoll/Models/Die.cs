using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    [Serializable]
    public class Die
    {
        public int DieNumber { get; set; }

        public int NumberOfSides { get; set; }

        public int Result { get; private set; }

        public bool ResultDropped { get; set; }

        public void RoleDie(Random randomGenerator)
        {            
            Result = randomGenerator.Next(1, NumberOfSides + 1);
        }        
    }
}
