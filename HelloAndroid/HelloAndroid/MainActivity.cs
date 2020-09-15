using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;

namespace HelloAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);

            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
            var spannable = new SpannableStringBuilder("Learn more at https://aka.ms/xamarin-quickstart");
            spannable.SetSpan(new StyleSpan(TypefaceStyle.Bold), 14, 47, 0);
            textView1.SetText(spannable, TextView.BufferType.Spannable);
        }
	}
}
