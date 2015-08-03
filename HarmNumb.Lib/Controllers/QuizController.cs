using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmNumb.Models;
using System.Timers;
using Android.Util;

namespace HarmNumb.Controllers
{
    public class QuizController
    {

        //we do not use int.MaxValue as we might increase this amount by a few milliseconds to make it unique
        const int WRONG_ANSWER_TIME = 30000;

        public int RepeatAfterXExercise { get; set; }
        public int TooSlowThreshold { get; set; }

        public double SecondsSinceExerciseStarted
        {
            get
            {
                return Math.Round(DateTime.Now.Subtract(currentExerciseStartedAt).TotalSeconds,2);
            }
        }

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
            Log.Debug("harm-numb", "Currently in queue:");
            foreach (var kv in unsuccessfullOrSlowAttempts)
            {
                Log.Debug("harm-numb",kv.Key + "  " + kv.Value.Key+":"+kv.Value.Note);
            }

            if (counter % RepeatAfterXExercise == 0 && unsuccessfullOrSlowAttempts.Count > 0)
            {
                //Repeat wrong answers
                int mostUrgentToRepeat = unsuccessfullOrSlowAttempts.Keys.Max();
                currentExercise = unsuccessfullOrSlowAttempts[mostUrgentToRepeat];

                unsuccessfullOrSlowAttempts.Remove(mostUrgentToRepeat);
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

        public bool AnswerExercise(int harmNumber)
        {
            bool result = currentExercise.Degree == harmNumber;
            return InternAnswerExercise(result);
        }

        public bool AnswerExercise(string note)
        {
            bool result = currentExercise.Note == note;
            return InternAnswerExercise(result);
        }

        public bool InternAnswerExercise(bool result)
        {
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