﻿using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            //if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            //{
            //    return OutputMessages.RaceCannotBeCompleted;
            //}
            //else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            //{
            //    return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            //}
            //else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            //{
            //    return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            //}
            //else
            //{
            //    double racingBehMul1 = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            //    double racingBehMul2 = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

            //    //•	chanceOfWinning = horsePower * drivingExperience * racingBehaviorMultiplier
            //    double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehMul1;
            //    double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehMul2;

            //    IRacer winner = chanceOfWinningOne > chanceOfWinningTwo ? racerOne : racerTwo;
            //    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
            //}

            return null;
        }
    }
}
