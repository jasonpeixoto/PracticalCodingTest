//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PracticalCodingTest.Droid
{
    [Activity(Label = "PracticalCodingTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            MainApp mainApp = new MainApp();
            LoadApplication(mainApp);
        }
    }
}