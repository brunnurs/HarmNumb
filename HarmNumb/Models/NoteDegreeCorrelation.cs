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

namespace HarmNumb.Models
{
    public class NoteDegreeCorrelation
    {
        public char Key { get; set; }
        public char Note { get; set; }
        public int Degree { get; set; }

        public NoteDegreeCorrelation(char key, char note, int degree)
        {
            Key = key;
            Note = note;
            Degree = degree;
        }

    }
}