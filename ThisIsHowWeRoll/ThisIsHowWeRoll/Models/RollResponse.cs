using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ThisIsHowWeRoll.Models
{
    public class RollResponse
    {
        private List<RollResult> RollResults { get; set; }

        public string DisplayResults
        {
            get
            {
                StringBuilder results = new StringBuilder();
                RollResults.ForEach(x => results.Append(x.Label).Append(": Result= ").Append(x.Result.ToString()).Append("; "));
                return results.ToString().TrimEnd().Remove(results.ToString().TrimEnd().Length - 1);
            }
        }

        public RollResponse()
        {
            RollResults = new List<RollResult>();
        }

        public void AddRollResult(RollResult rollResult)
        {
            RollResults.Add(rollResult);
        }
    }
}
