using System;
using HarmNumb.Controllers;
using NUnit.Framework;
using HarmNumb.Models;
using System.Threading;

namespace HarmNumb.Test
{
    [TestFixture]
    public class QuizControllerTest
    {
        QuizController controller;

        [SetUp]
        public void Initialization()
        {
            controller = new QuizController();
            controller.InitializeAllKeys();

            //Set the right values for this tests
            controller.RepeatAfterXExercise = 3;
            controller.TooSlowThreshold = 1;
        }

        [Test]
        public void GetFirstExercise()
        {
            //Act
            NoteDegreeCorrelation firstExercise = controller.GetNextExercise();

            //Assert
            Assert.IsNotNull(firstExercise);
        }

        [Test]
        public void DoExerciseCorrectly()
        {
            //Arrange
            NoteDegreeCorrelation exercise = controller.GetNextExercise();

            //Act
            bool correct = controller.AnswerExercise(exercise.Note);

            //Assert
            Assert.IsTrue(correct);
        }

        [Test]
        public void DoExerciseIncorrectly()
        {
            //Arrange
            controller.GetNextExercise();
            //Act
            var wrongResult = "xyz";
            bool correct = controller.AnswerExercise(wrongResult);

            //Assert
            Assert.IsFalse(correct);
        }

        [Test]
        public void RepeatFailedExercisesEveryNTime()
        {
            //Arrange
            var firstExercise = AnswerNextExerciseWrong();
            AnswerNextExerciseCorrectly();


            //Act
            var firstExerciseAgain = controller.GetNextExercise();

            //Assert
            Assert.AreEqual(firstExercise,firstExerciseAgain);
        }

        [Test]
        public void TwoExercisesTooSlow()
        {
            //Arrange
            AnswerNextExerciseCorrectly(1001);

            var secondExercise = AnswerNextExerciseCorrectly(1010);


            //Act
            //The second exercise should be repeated, as it ist the slowest
            var secondExerciseAgain = controller.GetNextExercise();

            //Assert
            Assert.AreEqual(secondExercise,secondExerciseAgain);
        }

        NoteDegreeCorrelation AnswerNextExerciseWrong(int waitBeforeAnswering = 0)
        {
            var exercise = controller.GetNextExercise();
            if (waitBeforeAnswering > 0)
            {
                Thread.Sleep(waitBeforeAnswering);
            }
            controller.AnswerExercise("xyz");

            return exercise;
        }

        NoteDegreeCorrelation AnswerNextExerciseCorrectly(int waitBeforeAnswering = 0)
        {
            var exercise = controller.GetNextExercise();
            if (waitBeforeAnswering > 0)
            {
                Thread.Sleep(waitBeforeAnswering);
            }
            controller.AnswerExercise(exercise.Note);

            return exercise;
        }
    }
}
