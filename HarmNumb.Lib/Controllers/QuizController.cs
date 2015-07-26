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
            this.allCorrelations = NoteDegreeCorrelationFactory.CreateCorrelationsForKey('C');
        }

        public NoteDegreeCorrelation GetNextExercise()
        {
            var rnd = new Random();
            currentExercise = allCorrelations[rnd.Next(0, allCorrelations.Count)];

            return currentExercise;
        }

        public bool AnswerExercise(char note)
        {
            return currentExercise.Note == note;
        }
    }
}