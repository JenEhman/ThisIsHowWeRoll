using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    [Serializable]
    public class RollRequest
    {
        public List<Roll> Rolls { get; set; }
    }
}
