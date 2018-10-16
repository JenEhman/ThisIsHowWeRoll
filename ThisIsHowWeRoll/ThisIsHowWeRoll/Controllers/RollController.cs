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
        // POST api/roll/1d20,3d4 DIS SUM,1d6
        [HttpPost("{rollRequestInput}")]
        public ActionResult<Models.RollResponse> Post(string rollRequestInput)
        {
            return ParseAndRollDice(rollRequestInput);
        }

        // GET api/roll/1d20,3d4 DIS SUM,1d6
        [HttpGet("{rollRequestInput}")]
        public ActionResult<Models.RollResponse> Get(string rollRequestInput)
        {
            return ParseAndRollDice(rollRequestInput);
        }
    
        #region Not Implemented 
        // GET api/roll
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Just Roll With It..." };
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
        #endregion

        #region Private Methods

        private static Models.RollResponse ParseAndRollDice(string rollRequestInput)
        {
            var splitRollRequestInput = rollRequestInput.ToUpper().Split(",");
            if (splitRollRequestInput.Count() > 0)
            {
                Models.RollRequest rollRequest = new Models.RollRequest();
                Models.RollResponse rollResponse = new Models.RollResponse();

                foreach (string rollInput in splitRollRequestInput)
                {
                    rollRequest.Rolls.Add(new Models.Roll(rollInput));
                }

                //For each requested roll, roll the die
                int rollCount = 1;
                foreach (var roll in rollRequest.Rolls)
                {
                    Models.RollResult rollResult = new Models.RollResult();

                    //Roll all the dice in the roll
                    //we are using the same random number generator for all the die roles
                    //to ensure that we do not get repeats from initializing it too close together.
                    var randomGenerator = new Random();
                    foreach (var die in roll.Dice)
                    {
                        die.RoleDie(randomGenerator);
                    }

                    //figure out if any need to be dropped because of advantage/disadvantage
                    roll.SetAdvantages();

                    //Add the roll to the response
                    rollResult.Roll = roll;
                    rollResult.RollNumber = rollCount++;
                    rollResponse.AddRollResult(rollResult);
                }

                return rollResponse;
            }
            else
            {
                throw new Exception("No roll data present.");
            }
        }
        
        #endregion
    }
}
