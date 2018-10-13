using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    [Serializable]
    public class RollResult
    {
        public Roll Roll { get; set; }

        public string Label { get; set; }

        public string Result { get; set; }

    }
}
