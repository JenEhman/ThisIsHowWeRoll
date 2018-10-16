using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    [Serializable]
    public class RollResult
    {
        public Roll Roll { get; set; }

        public int RollNumber { get; set; }
        
        public string Label
        {
            get { return "Roll " + RollNumber.ToString() + "(" + Roll.RollInput + ")"; }
        }

        public string Result { get
            {
                StringBuilder result = new StringBuilder();
                Roll.Dice.ForEach(x => {
                    result
                    .Append(" ")
                    .Append(x.Result.ToString())
                    .Append(x.ResultDropped ? "(DROP)" : "");
                    });
                result.Append(Roll.HasSum ? ", SUM = " + Roll.SumOfRoll.ToString(): "");
                return result.ToString().TrimStart();
            }
        }        
    }
}
