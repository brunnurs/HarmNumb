using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmNumb.Models;

namespace HarmNumb.Controllers
{
    public class QuizController
    {
        List<NoteDegreeCorrelation> allCorrelations;

        NoteDegreeCorrelation currentExercise;

        public void Initialize()
        {
            this.allCorrelations = NoteDegreeCorrelationFactory.GetCorrelationsForKey("C");
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("B"));
        }

        public NoteDegreeCorrelation GetNextExercise()
        {
            var rnd = new Random();
            currentExercise = allCorrelations[rnd.Next(0, allCorrelations.Count)];

            return currentExercise;
        }

        public bool AnswerExercise(string note)
        {
            return currentExercise.Note == note;
        }
    }
}