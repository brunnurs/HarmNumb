using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmNumb.Models;

namespace HarmNumb.Controllers
{
    public class NoteDegreeCorrelationFactory
    {
        public static List<NoteDegreeCorrelation> CreateCorrelationsForKey(char key)
        {
            var allCorrelations = new List<NoteDegreeCorrelation>();

            switch(key)
            {
                case 'C':
                    CreateCorrelationsForKeyC(allCorrelations);
                    break;
            }

            return allCorrelations;
        }

        private static void CreateCorrelationsForKeyC(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("C", 'c', 1));
            correlations.Add(new NoteDegreeCorrelation("C", 'd', 2));
            correlations.Add(new NoteDegreeCorrelation("C", 'e', 3));
            correlations.Add(new NoteDegreeCorrelation("C", 'f', 4));
            correlations.Add(new NoteDegreeCorrelation("C", 'g', 5));
            correlations.Add(new NoteDegreeCorrelation("C", 'a', 6));
            correlations.Add(new NoteDegreeCorrelation("C", 'b', 7));
        }
    }
}