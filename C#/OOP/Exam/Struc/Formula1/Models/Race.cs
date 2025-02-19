﻿using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private List<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get { return this.raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                else
                {
                    this.raceName = value;
                }
            }
        }
        public int NumberOfLaps
        {
            get { return this.numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                else
                {
                    this.numberOfLaps = value;
                }
            }
        }

        public bool TookPlace { get; set; } = false;
        public ICollection<IPilot> Pilots
        {
            get { return this.pilots; }
        }
        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            string checkBool = String.Empty;
            if (TookPlace == true)
            {
                checkBool = "Yes";
            }
            else
            {
                checkBool = "No";
            }
            sb.Append(
                $"The {this.RaceName} race has:" + Environment.NewLine +
                $"Participants: {this.Pilots.Count}" + Environment.NewLine +
                $"Number of laps: {this.NumberOfLaps}" + Environment.NewLine +
                $"Took place: {checkBool}");
            return sb.ToString().TrimEnd();
        }
    }
}
