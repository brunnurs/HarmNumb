using System;
using Android.Widget;
using Android.OS;
using Android.App;
using System.Threading.Tasks;
using Java.Util.Logging;
using Android.Util;

namespace HarmNumb
{
    public class QuizResultHandler
    {
        const int RESULT_DISPLAYED_TIME = 800;

        Activity activity;

        public QuizResultHandler(Activity activity)
        {
            this.activity = activity;
        }

        public async Task ShowShortResultAsync(bool result)
        {
            Toast toast = new Toast(activity);

            ImageView imgView = new ImageView(activity); 
            toast.View = imgView; 

            if(result)
                imgView.SetImageResource(Resource.Drawable.ic_thumb_up_black); 
            else
                imgView.SetImageResource(Resource.Drawable.ic_thumb_down_black); 
                

            toast.Show();

            await Task.Delay(RESULT_DISPLAYED_TIME);
            try
            {
                toast.Cancel();
            }
            catch(Exception ex)
            {
                Log.Error("HarmNumb", ex.ToString());
            }
        }
    }
}

