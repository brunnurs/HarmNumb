using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmNumb.Models;

namespace HarmNumb.Controllers
{
    public class NoteDegreeCorrelationFactory
    {
        public static List<NoteDegreeCorrelation> GetCorrelationsForKey(string key)
        {
            var allCorrelations = new List<NoteDegreeCorrelation>();

            switch(key)
            {
                case "C":
                    CreateCorrelationsForKeyC(allCorrelations);
                    break;
                case "B":
                    CreateCorrelationsForKeyB(allCorrelations);
                    break;
            }

            return allCorrelations;
        }

        private static void CreateCorrelationsForKeyC(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("C", "C", 1));
            correlations.Add(new NoteDegreeCorrelation("C", "D", 2));
            correlations.Add(new NoteDegreeCorrelation("C", "E", 3));
            correlations.Add(new NoteDegreeCorrelation("C", "F", 4));
            correlations.Add(new NoteDegreeCorrelation("C", "G", 5));
            correlations.Add(new NoteDegreeCorrelation("C", "A", 6));
            correlations.Add(new NoteDegreeCorrelation("C", "B", 7));
        }

        private static void CreateCorrelationsForKeyB(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("B", "B", 1));
            correlations.Add(new NoteDegreeCorrelation("B", "C#", 2));
            correlations.Add(new NoteDegreeCorrelation("B", "D#", 3));
            correlations.Add(new NoteDegreeCorrelation("B", "E", 4));
            correlations.Add(new NoteDegreeCorrelation("B", "F#", 5));
            correlations.Add(new NoteDegreeCorrelation("B", "G#", 6));
            correlations.Add(new NoteDegreeCorrelation("B", "A#", 7));
        }
    }
}