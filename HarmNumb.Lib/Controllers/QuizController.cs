using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmNumb.Models;
using System.Timers;

namespace HarmNumb.Controllers
{
    public class QuizController
    {

        //we do not use int.MaxValue as we might increase this amount by a few milliseconds to make it unique
        const int WRONG_ANSWER_TIME = 30000;

        public int RepeatAfterXExercise { get; set; }
        public int TooSlowThreshold { get; set; }

        Random rnd;

        List<NoteDegreeCorrelation> allCorrelations;

        Dictionary<int,NoteDegreeCorrelation> unsuccessfullOrSlowAttempts;

        NoteDegreeCorrelation currentExercise;
        DateTime currentExerciseStartedAt;

        int counter;

        public QuizController()
        {
            rnd = new Random();
            unsuccessfullOrSlowAttempts = new Dictionary<int, NoteDegreeCorrelation>();

            counter = 1;

            //Set defaults
            RepeatAfterXExercise = 3;
            TooSlowThreshold = 2;
        }

        public void InitializeAllKeys()
        {
            this.allCorrelations = NoteDegreeCorrelationFactory.AllCorrelations;
        }

        public void InitializeKey(string selectedKey)
        {
            this.allCorrelations = NoteDegreeCorrelationFactory.GetCorrelationsForKey(selectedKey);
        }

        public NoteDegreeCorrelation GetNextExercise()
        {
            if (counter % RepeatAfterXExercise == 0 && unsuccessfullOrSlowAttempts.Count > 0)
            {
                //Repeat wrong answers
                currentExercise = unsuccessfullOrSlowAttempts[unsuccessfullOrSlowAttempts.Keys.Max()];
            }
            else
            {
                //Random exercise
                currentExercise = allCorrelations[rnd.Next(0, allCorrelations.Count)];
            }

            counter++;
            currentExerciseStartedAt = DateTime.Now;
            return currentExercise;

        }

        public bool AnswerExercise(string note)
        {
            bool result = currentExercise.Note == note;

            TimeSpan timeNeededToAnswer = DateTime.Now.Subtract(currentExerciseStartedAt);

            if (!result)
            {
                AddCurrentExerciseToUnsuccessfullOrSlowAttempts(WRONG_ANSWER_TIME);   
            }
            else if (timeNeededToAnswer.TotalSeconds > TooSlowThreshold)
            {
                AddCurrentExerciseToUnsuccessfullOrSlowAttempts((int)timeNeededToAnswer.TotalMilliseconds);   
            }

            return result;
        }

        void AddCurrentExerciseToUnsuccessfullOrSlowAttempts(int timeNeededToAnswer)
        {
            //to avoid having the exact amount of time twice. It doesnt matter if we increase the 
            //time a few milliseconds.
            while (unsuccessfullOrSlowAttempts.ContainsKey(timeNeededToAnswer))
            {
                timeNeededToAnswer++;
            }

            unsuccessfullOrSlowAttempts.Add(timeNeededToAnswer, currentExercise);
        }
    }
}