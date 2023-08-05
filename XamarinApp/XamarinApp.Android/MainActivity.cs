using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using XamarinApp.Media;
using XamarinApp.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;

//Anotação que indica que a classe implementa uma interface dentro do DependencyService
[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace XamarinApp.Droid
{
    [Activity(Label = "XamarinApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            /* 
             * A partir do Context eu sei qual é a Activity
             * A partir da activity local consigo ativar a activity externa
            */
            Activity activity = Forms.Context as Activity;
            activity.StartActivityForResult(intent, 0);
        }
    }
}