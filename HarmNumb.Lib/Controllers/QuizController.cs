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

        public void InitializeAllKeys()
        {
            this.allCorrelations = NoteDegreeCorrelationFactory.GetCorrelationsForKey("C");
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("G"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("D"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("A"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("E"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("B"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("F#"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("F"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("Bb"));            
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("Eb"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("Ab"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("Db"));
            this.allCorrelations.AddRange(NoteDegreeCorrelationFactory.GetCorrelationsForKey("Gb"));
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