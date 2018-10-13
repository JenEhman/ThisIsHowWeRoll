using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThisIsHowWeRoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollController : ControllerBase
    {
        // GET api/roll
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //return new string[] { "value1", "value2" };
            throw new NotImplementedException();
        }

        // GET api/roll/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //return "value";
            throw new NotImplementedException();
        }

        // POST api/roll
        [HttpPost]
        public void Post([FromBody] string rollRequestInput)
        {
            var splitRollRequestInput = rollRequestInput.Split(",");
            if(splitRollRequestInput.Count() > 0)
            {
                Models.RollRequest rollRequest = new Models.RollRequest();
                rollRequest.Rolls = new List<Models.Roll>();

                foreach (string rollInput in splitRollRequestInput)
                {
                    var parsedRoll = ParseRoll(rollInput);
                    rollRequest.Rolls.Add(parsedRoll); 
                }

                //For each requested roll, roll the die
                foreach(var roll in rollRequest.Rolls)
                {
                    //Roll all the dice in the roll
                    foreach(var die in roll.Dice)
                    {
                        die.RoleDie();
                    }

                    //then determine the advantage/disadvantage
                    if (roll.HasAdvantage)
                    {
                        //Need to mark the lowerest number as "ResultDropped"
                    }

                    if (roll.HasDisadvantage)
                    {
                        //Need to mark the highest number as "ResultDropped"
                    }
                }
            }
            else
            {
                throw new Exception("No roll data present.");
            }
        }

        private static Models.Roll ParseRoll(string splitRollsInput)
        {
            Models.Roll newRoll = new Models.Roll();
            var diceParams = splitRollsInput.ToLower().Split(" ");

            //First add all the Die with the correct number of sides
            //XdY => where X= number of dice to roll and Y= number of sides on each die
            var dieParams = diceParams[0].ToLower().Split("d");
            newRoll.Dice = new List<Models.Die>();
            for (int i = 0; i <= Convert.ToInt16(dieParams[0]); i++)
            {
                Models.Die newDie = new Models.Die() { NumberOfSides = Convert.ToInt16(dieParams[1]), ResultDropped = false };
                newRoll.Dice.Add(newDie);
            }

            //Now add if this roll needs to be with advantage, with disadvantage, or be summed
            if (diceParams.Contains("SUM"))
                newRoll.HasSum = true;

            if (diceParams.Contains("ADV"))
                newRoll.HasAdvantage = true;

            if (diceParams.Contains("DIS"))
                newRoll.HasDisadvantage = true;

            return newRoll;
        }

        // PUT api/roll/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/roll/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
