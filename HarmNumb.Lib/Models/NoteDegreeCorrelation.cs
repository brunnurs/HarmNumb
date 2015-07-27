using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HarmNumb.Models
{
    public class NoteDegreeCorrelation
    {
        public string Key { get; set; }
        public string Note { get; set; }
        public int Degree { get; set; }

        public NoteDegreeCorrelation(string key, string note, int degree)
        {
            Key = key;
            Note = note;
            Degree = degree;
        }

    }
}