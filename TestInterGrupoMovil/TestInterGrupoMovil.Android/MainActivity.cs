using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;
using System.Net.Security;
using Acr.UserDialogs;

namespace TestInterGrupoMovil.Droid
{
    //[Activity(Label = "TestInterGrupoMovil", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public static MainActivity Current { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicy) =>
            {
                if (sslPolicy == SslPolicyErrors.None)
                    return true;

                if (sslPolicy == SslPolicyErrors.RemoteCertificateChainErrors &&
                   ((HttpWebRequest)sender).RequestUri.AbsoluteUri.Equals("a trusted URL"))
                    return true;

                return false;
            };

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(this);
            
            LoadApplication(new App());
            Window.SetStatusBarColor(Android.Graphics.Color.Rgb(144, 143, 147));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}