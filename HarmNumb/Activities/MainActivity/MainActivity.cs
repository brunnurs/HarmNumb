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
using System.Timers;

namespace HarmNumb
{
    [Activity(Label = "Harm Numb",ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape, MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : AppCompatActivity
    {
        public const string PREFERENCE_FILE_NAME = "HarmNumbPreferences" ;

        List<Button> allButtons;

        Button btnNr1;
        Button btnNr2;
        Button btnNr3;
        Button btnNr4;
        Button btnNr5;
        Button btnNr6;
        Button btnNr7;

        ImageView imgKey;
        TextView txtHarmNumber;
        TextView txtKey;
        TextView txtExerciseTimer;

        bool displayNoteButtons;

        QuizResultHandler quizResultHandler;
        KeyImagePathResolver keyImagePathResolver;
        QuizController quizController;

        Timer exerciseTimer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main_activity);

            InitializeQuizController();

            keyImagePathResolver = new KeyImagePathResolver();
            quizResultHandler = new QuizResultHandler(this);
            allButtons = new List<Button>();

            exerciseTimer = new Timer(100);
            exerciseTimer.Elapsed += ExerciseTimer_Elapsed;

            AddToolbarLikeActionbar();

            ConnectUIElements();
        }

        protected override void OnResume()
        {
            base.OnStart();
            var nextExercise = quizController.GetNextExercise();

            DisplayExercise(nextExercise);
        }

        protected override void OnPause()
        {
            base.OnPause();
            exerciseTimer.Stop();
        }



        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok) 
            {
                InitializeQuizController();
            }
        }

        void InitializeQuizController()
        {
            ISharedPreferences preferences = GetSharedPreferences(MainActivity.PREFERENCE_FILE_NAME,FileCreationMode.Private);

            quizController = new QuizController();

            string selectedKey = preferences.GetString("selected_key", SettingsActivity.SPECIAL_KEY_ALL_KEYS);

            if (selectedKey == SettingsActivity.SPECIAL_KEY_ALL_KEYS)
            {
                quizController.InitializeAllKeys();
            }
            else
            {
                quizController.InitializeKey(selectedKey);
            }

            quizController.RepeatAfterXExercise = preferences.GetInt("repeat_exercises",3);
            quizController.TooSlowThreshold = preferences.GetInt("answer_too_slow",2);

            this.displayNoteButtons = preferences.GetBoolean("display_note_buttons",true);
        }

        private void DisplayExercise(NoteDegreeCorrelation nextExercise)
        {
            DisplayButtonLabels(nextExercise);

            imgKey.SetImageDrawable(Resources.GetDrawable(keyImagePathResolver.GetKeyDrawableByKey(nextExercise.Key)));
            txtKey.Text = String.Format("{0}",nextExercise.Key);

            if (displayNoteButtons)
            {
                txtHarmNumber.Text = nextExercise.Degree.ToString();
            }
            else
            {
                txtHarmNumber.Text = nextExercise.Note;
            }

            exerciseTimer.Start();
        }

        void ExerciseTimer_Elapsed (object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                txtExerciseTimer.Text = quizController.SecondsSinceExerciseStarted.ToString();
            });
        }

        private async void ClickedButtonWithNumber(string btnText)
        {
            exerciseTimer.Stop();

            bool result;
            if (displayNoteButtons)
            {
                result = quizController.AnswerExercise(btnText);
            }
            else
            {
                result = quizController.AnswerExercise(int.Parse(btnText));
            }

            await quizResultHandler.ShowShortResultAsync(result);

            var nextExercise = quizController.GetNextExercise();

            DisplayExercise(nextExercise);
        }

        private void ConnectUIElements()
        {
            imgKey = FindViewById<ImageView>(Resource.Id.img_key);

            txtHarmNumber = FindViewById<TextView>(Resource.Id.txt_harm_number);
            txtKey = FindViewById<TextView>(Resource.Id.txt_key);   
            txtExerciseTimer = FindViewById<TextView>(Resource.Id.txt_timer);

            btnNr1 = FindViewById<Button>(Resource.Id.btn_nr_1);
            btnNr1.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
            allButtons.Add(btnNr1);

            btnNr2 = FindViewById<Button>(Resource.Id.btn_nr_2);
            btnNr2.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
            allButtons.Add(btnNr2);

            btnNr3 = FindViewById<Button>(Resource.Id.btn_nr_3);
            btnNr3.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
            allButtons.Add(btnNr3);

            btnNr4 = FindViewById<Button>(Resource.Id.btn_nr_4);
            btnNr4.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
            allButtons.Add(btnNr4);

            btnNr5 = FindViewById<Button>(Resource.Id.btn_nr_5);
            btnNr5.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
            allButtons.Add(btnNr5);

            btnNr6 = FindViewById<Button>(Resource.Id.btn_nr_6);
            btnNr6.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
            allButtons.Add(btnNr6);

            btnNr7 = FindViewById<Button>(Resource.Id.btn_nr_7);
            btnNr7.Click += (object sender, EventArgs e) => ClickedButtonWithNumber(((Button)sender).Text);
            allButtons.Add(btnNr7);
        }

        void DisplayButtonLabels(NoteDegreeCorrelation nextExercise)
        {
            List<NoteDegreeCorrelation> allCorrelationsForKey = NoteDegreeCorrelationFactory.GetCorrelationsForKey(nextExercise.Key);

            //Randomize, because otherwise it's too easy, as the degree is ordered.
            allCorrelationsForKey = allCorrelationsForKey.RandomizeOrder();

            for (int i = 0; i < 7; i++)
            {
                if (displayNoteButtons)
                {
                    allButtons[i].Text = allCorrelationsForKey[i].Note;
                }
                else
                {
                    allButtons[i].Text = (i + 1).ToString();
                }
            }
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

