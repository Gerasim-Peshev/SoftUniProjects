using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else
            {
                //•	chanceOfWinning = horsePower * drivingExperience * racingBehaviorMultiplier
                var firstChanceToWin =
                    racerOne.Car.HorsePower * racerOne.DrivingExperience * 
                    (racerOne.RacingBehavior == "strict"
                        ? 1.2
                        : 1.1);
                var secondChanceToWin =
                    racerTwo.Car.HorsePower * racerTwo.DrivingExperience *
                                        (racerTwo.RacingBehavior == "strict"
                                            ? 1.2
                                            : 1.1);

                var winner = firstChanceToWin > secondChanceToWin ? racerOne : racerTwo;

                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
            }
        }
    }
}
