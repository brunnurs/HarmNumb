using System;
using Android.Graphics.Drawables;
using Android.App;
using System.Collections.Generic;

namespace HarmNumb
{
    public class KeyImagePathResolver
    {
        Dictionary<string, int> keyDrawableMapping;

        public KeyImagePathResolver()
        {
            keyDrawableMapping = new Dictionary<string, int>();

            keyDrawableMapping.Add("C", Resource.Drawable.keyC);
            keyDrawableMapping.Add("G", Resource.Drawable.keyG);
            keyDrawableMapping.Add("D", Resource.Drawable.keyD);
            keyDrawableMapping.Add("A", Resource.Drawable.keyA);
            keyDrawableMapping.Add("E", Resource.Drawable.keyE);
            keyDrawableMapping.Add("B", Resource.Drawable.keyB);
            keyDrawableMapping.Add("F#", Resource.Drawable.keyFSharp);
            keyDrawableMapping.Add("F", Resource.Drawable.keyF);
            keyDrawableMapping.Add("Bb", Resource.Drawable.keyBb);
            keyDrawableMapping.Add("Eb", Resource.Drawable.keyEb);
            keyDrawableMapping.Add("Ab", Resource.Drawable.keyAb);
            keyDrawableMapping.Add("Db", Resource.Drawable.keyDb);
            keyDrawableMapping.Add("Gb", Resource.Drawable.keyGb);
        }

        public int GetKeyDrawableByKey(string key)
        {
            return keyDrawableMapping[key];
        }
    }
}

