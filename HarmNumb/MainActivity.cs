using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using HarmNumb.Controllers;
using HarmNumb.Models;

namespace HarmNumb
{
    [Activity(Label = "Harm Numb", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity
    {
        QuizController quizController;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            quizController = new QuizController();
            quizController.Initialize();

            ConnectButtons();
        }

        protected override void OnStart()
        {
            base.OnStart();
            var nextExercise = quizController.GetNextExercise();

            DisplayExercise(nextExercise);
        }

        private void DisplayExercise(NoteDegreeCorrelation nextExercise)
        {
            var imgKey = FindViewById<ImageView>(Resource.Id.img_key);
            var txtTimer = FindViewById<TextView>(Resource.Id.txt_timer);

            switch (nextExercise.Key)
            {
                case "C":
                    imgKey.SetImageResource(Resource.Drawable.keyC);
                    //Only temporary
                    txtTimer.Text = String.Format("({0})",nextExercise.Key);
                    break;
            }

            var txtHarmNumber = FindViewById<TextView>(Resource.Id.txt_harm_number);
            txtHarmNumber.Text = nextExercise.Degree.ToString();
        }

        private void ClickedButtonWithNumber(int btnNumber)
        {
            //because it's not 0-based
            btnNumber--;

            char startChar = 'a';
            char answer = (char)((int)startChar + btnNumber);

            bool result = quizController.AnswerExercise(answer);
            ShowResult(result);

            var nextExercise = quizController.GetNextExercise();

            DisplayExercise(nextExercise);
        }

        private void ShowResult(bool result)
        {
            string message = result ? "Gut gemacht!" : "Leider falsch";
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

        private void ConnectButtons()
        {
            var btnNr1 = FindViewById<Button>(Resource.Id.btn_nr_1);
            btnNr1.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(1);

            Button btnNr2 = FindViewById<Button>(Resource.Id.btn_nr_2);
            btnNr2.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(2);

            Button btnNr3 = FindViewById<Button>(Resource.Id.btn_nr_3);
            btnNr3.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(3);

            Button btnNr4 = FindViewById<Button>(Resource.Id.btn_nr_4);
            btnNr4.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(4);

            Button btnNr5 = FindViewById<Button>(Resource.Id.btn_nr_5);
            btnNr5.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(5);

            Button btnNr6 = FindViewById<Button>(Resource.Id.btn_nr_6);
            btnNr6.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(6);

            Button btnNr7 = FindViewById<Button>(Resource.Id.btn_nr_7);
            btnNr7.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(7);
        }
    }
}

