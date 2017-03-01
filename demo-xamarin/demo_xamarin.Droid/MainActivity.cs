using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace demo_xamarin.Droid
{
	[Activity (Label = "demo_xamarin.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.get);

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            dynamic json = await demoTest.GET("http://localhost:24939/api/PainelTemporarioAPI/").ConfigureAwait(false);
            FindViewById<TextView>(Resource.Id.getText).Text = (string)json["localidade"];
        }
    }
}


