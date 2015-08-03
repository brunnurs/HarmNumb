using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using System.Collections.Generic;
using HarmNumb.Controllers;
using HarmNumb.Models;
using System.Linq;
using Android.Graphics;
using Android.Support.V7.App;
using Android.Widget;

namespace HarmNumb
{
    [Activity(Label = "Harm Numb",ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape, MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : AppCompatActivity
    {
        Button btnNr1;
        Button btnNr2;
        Button btnNr3;
        Button btnNr4;
        Button btnNr5;
        Button btnNr6;
        Button btnNr7;

        QuizResultHandler quizResultHandler;
        KeyImagePathResolver keyImagePathResolver;
        QuizController quizController;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main_activity);

            quizController = new QuizController();
            quizController.InitializeAllKeys();

            keyImagePathResolver = new KeyImagePathResolver();
            quizResultHandler = new QuizResultHandler(this);


            AddToolbarLikeActionbar();


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
            DisplayButtonLabels(nextExercise);

            var imgKey = FindViewById<ImageView>(Resource.Id.img_key);
            var txtKey = FindViewById<TextView>(Resource.Id.txt_key);

            imgKey.SetImageDrawable(Resources.GetDrawable(keyImagePathResolver.GetKeyDrawableByKey(nextExercise.Key)));
            txtKey.Text = String.Format("({0})",nextExercise.Key);

            var txtHarmNumber = FindViewById<TextView>(Resource.Id.txt_harm_number);
            txtHarmNumber.Text = nextExercise.Degree.ToString();
        }

        private async void ClickedButtonWithNumber(string btnText)
        {
            bool result = quizController.AnswerExercise(btnText);

            await quizResultHandler.ShowShortResultAsync(result);

            var nextExercise = quizController.GetNextExercise();

            DisplayExercise(nextExercise);
        }

        private void ConnectButtons()
        {
            btnNr1 = FindViewById<Button>(Resource.Id.btn_nr_1);
            btnNr1.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);

            btnNr2 = FindViewById<Button>(Resource.Id.btn_nr_2);
            btnNr2.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);

            btnNr3 = FindViewById<Button>(Resource.Id.btn_nr_3);
            btnNr3.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);

            btnNr4 = FindViewById<Button>(Resource.Id.btn_nr_4);
            btnNr4.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);

            btnNr5 = FindViewById<Button>(Resource.Id.btn_nr_5);
            btnNr5.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);

            btnNr6 = FindViewById<Button>(Resource.Id.btn_nr_6);
            btnNr6.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);

            btnNr7 = FindViewById<Button>(Resource.Id.btn_nr_7);
            btnNr7.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
        }

        void DisplayButtonLabels(NoteDegreeCorrelation nextExercise)
        {
            List<NoteDegreeCorrelation> allCorrelationsForKey = NoteDegreeCorrelationFactory.GetCorrelationsForKey(nextExercise.Key);

            btnNr1.Text = allCorrelationsForKey.First(c=>c.Degree == 1).Note;
            btnNr2.Text = allCorrelationsForKey.First(c=>c.Degree == 2).Note;
            btnNr3.Text = allCorrelationsForKey.First(c=>c.Degree == 3).Note;
            btnNr4.Text = allCorrelationsForKey.First(c=>c.Degree == 4).Note;
            btnNr5.Text = allCorrelationsForKey.First(c=>c.Degree == 5).Note;
            btnNr6.Text = allCorrelationsForKey.First(c=>c.Degree == 6).Note;
            btnNr7.Text = allCorrelationsForKey.First(c=>c.Degree == 7).Note;

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_activity_menu, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_open_settings)
            {
                Intent settingActivity = new Intent(this, typeof(SettingsActivity));
                settingActivity.AddFlags(ActivityFlags.ClearTop);
                //Start for result, so we can detect when user comes back from configuration-activity and take action.
                StartActivityForResult(settingActivity, 443);

                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }

        void AddToolbarLikeActionbar()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            }
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }
        }
    }
}

