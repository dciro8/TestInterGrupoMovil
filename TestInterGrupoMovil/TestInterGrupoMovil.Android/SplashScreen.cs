using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace TestInterGrupoMovil.Droid
{
    [Activity(Label = "Test InterGrupo", Icon = "@drawable/PlanetaTierra", Theme = "@style/MyParameter", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        LinearLayout LinearId;

        ImageView imageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.splash_layout);


            LinearId = FindViewById<LinearLayout>(Resource.Id.LinearId);

            imageView = FindViewById<ImageView>(Resource.Id.imageView);


            Animation anim = new ScaleAnimation(
                1f, 1f, 0f, 1f, 0f, 1f);

            anim.FillAfter = true;
            anim.Duration = 2000;
            LinearId.Animation = anim;
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        public string GetVersion()
        {
            var context = global::Android.App.Application.Context;

            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionName;
        }

        async void SimulateStartup()
        {
            await Task.Delay(3000); // Simulate a bit of startup work.
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            OverridePendingTransition(0, 0);
        }
    }
}