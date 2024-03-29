﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTester
{
    public class AutoWord : IComparable<AutoWord>
    {

        private string word;
        private Double frequency;
        private Double currentDistance;
        public AutoWord(string word, string freq)
        {
            this.word = word;
            frequency = Convert.ToDouble(freq);
            currentDistance = 0;
        }


        public int CompareTo(AutoWord other)
        {
            if (this.currentDistance == other.currentDistance)
            {
                return this.word.CompareTo(other.word);
            }
            // Default to salary sort. [High to low]
            return this.currentDistance.CompareTo(other.currentDistance);
        }

        public Double CurrentDistance { get => currentDistance; set => currentDistance = value; }
        public Double Frequency { get => frequency; set => frequency = value; }
        public string Word { get => word; set => word = value; }
    }
}
