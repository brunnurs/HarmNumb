
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
        Spinner keySpinner;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.settings_activity);

            SetUIHandlers();

            keySpinner.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, ComposeSpinnerValues());

            AddToolbarLikeActionbar();
        }

        void SetUIHandlers()
        {
            this.keySpinner = FindViewById<Spinner>(Resource.Id.sp_keys);
        }

        List<string> ComposeSpinnerValues()
        {
            var allCorrelations = NoteDegreeCorrelationFactory.AllCorrelations;

            List<string> keysOnly = new List<string>(from c in allCorrelations
                                        group c.Key by c.Key into k
                                        select k.Key);

            //and an entry for all keys
            keysOnly.Add("All keys");

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

