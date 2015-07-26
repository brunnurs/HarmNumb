using System;
using HarmNumb.Controllers;
using NUnit.Framework;
using HarmNumb.Models;

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
            controller.Initialize();
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
        public void AnswerExerciseCorrectly()
        {
            //Arrange
            NoteDegreeCorrelation exercise = controller.GetNextExercise();

            //Act
            bool correct = controller.AnswerExercise(exercise.Note);

            //Assert
            Assert.IsTrue(correct);
        }

        [Test]
        public void AnswerExerciseIncorrectly()
        {
            //Arrange
            NoteDegreeCorrelation exercise = controller.GetNextExercise();
            char wrongResult = (char)((int)exercise.Note + 1);
            //Act
            bool correct = controller.AnswerExercise(wrongResult);

            //Assert
            Assert.IsFalse(correct);
        }
    }
}
