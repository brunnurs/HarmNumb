
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using HarmNumb.Controllers;

namespace HarmNumb
{
    [Activity(Label = "Settings",ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
    public class SettingsActivity : AppCompatActivity
    {
        public const string SPECIAL_KEY_ALL_KEYS = "All keys";

        Spinner keySpinner;
        ArrayAdapter<string> keySpinnerAdapter;

        EditText txtRepeatExercises;
        EditText txtAnswerTooSlow;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.settings_activity);

            SetUIHandlers();

            keySpinnerAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, ComposeSpinnerValues());
            keySpinner.Adapter = keySpinnerAdapter;

            AddToolbarLikeActionbar();

            DisplayValuesByStoredPreferences();
        }

        void DisplayValuesByStoredPreferences()
        {
            ISharedPreferences preferences = GetSharedPreferences(MainActivity.PREFERENCE_FILE_NAME,FileCreationMode.Private);

            string selectedKey = preferences.GetString("selected_key", SPECIAL_KEY_ALL_KEYS);
            keySpinner.SetSelection(keySpinnerAdapter.GetPosition(selectedKey));

            int repeatExercises = preferences.GetInt("repeat_exercises",3);
            txtRepeatExercises.Text = repeatExercises.ToString();

            int answerTooSlow = preferences.GetInt("answer_too_slow",2);
            txtAnswerTooSlow.Text = answerTooSlow.ToString();
        }

        void SaveValuesToStoredPreferences()
        {
            ISharedPreferences preferences = GetSharedPreferences(MainActivity.PREFERENCE_FILE_NAME,FileCreationMode.Private);

            var editor = preferences.Edit();

            editor.PutString("selected_key",(string)keySpinner.SelectedItem);

            editor.PutInt("repeat_exercises",int.Parse(txtRepeatExercises.Text));

            editor.PutInt("answer_too_slow",int.Parse(txtAnswerTooSlow.Text));

            editor.Commit();
        }

        void SetUIHandlers()
        {
            this.keySpinner = FindViewById<Spinner>(Resource.Id.sp_keys);
            this.txtRepeatExercises = FindViewById<EditText>(Resource.Id.txt_repeat_exercises);
            this.txtAnswerTooSlow = FindViewById<EditText>(Resource.Id.txt_answer_too_slow);

        }

        List<string> ComposeSpinnerValues()
        {
            var allCorrelations = NoteDegreeCorrelationFactory.AllCorrelations;

            List<string> keysOnly = new List<string>(from c in allCorrelations
                                        group c.Key by c.Key into k
                                        select k.Key);

            //and an entry for all keys
                    keysOnly.Add(SPECIAL_KEY_ALL_KEYS);

            return keysOnly;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.settings_activity_menu, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_save_configuration)
            {
                SaveValuesToStoredPreferences();

                SetResult(Result.Ok);
                Finish();

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

