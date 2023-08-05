﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using XamarinApp.Media;
using XamarinApp.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;
using Xamarin.Essentials;
using Android;
using AndroidX.Core.App;
using Java.IO;

//Anotação que indica que a classe implementa uma interface dentro do DependencyService
[assembly: Dependency(typeof(MainActivity))]
namespace XamarinApp.Droid
{
    [Activity(Label = "XamarinApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        private const int CAMERA_PERMISSION_REQUEST_CODE = 100;
        private static readonly string[] CameraPermissions = { Manifest.Permission.Camera };
        static File ArquivoImagem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void TirarFoto()
        {
            /*
             * Definir permissões - XamarinApp.Android - Properties - Android Manifest - Required Permissions
            */

            /* 
             * A partir do Context eu sei qual é a Activity
             * A partir da activity local consigo ativar a activity externa
            */
            Activity activity = Platform.CurrentActivity;

            if(activity != null && CheckCameraPermission())
            {
                //Descreve qual ação eu quero fazer
                Intent intent = new Intent(MediaStore.ActionImageCapture);

                ArquivoImagem = PegarArquivoImagem();

                intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(arquivoImagem));

                activity.StartActivityForResult(intent, 0);
            }
            else
            {
                RequestCameraPermission();
            }
        }

        private bool CheckCameraPermission()
        {
            return ActivityCompat.CheckSelfPermission(Platform.CurrentActivity, Manifest.Permission.Camera) == Permission.Granted;
        }

        private void RequestCameraPermission()
        {
            ActivityCompat.RequestPermissions(Platform.CurrentActivity, CameraPermissions, CAMERA_PERMISSION_REQUEST_CODE);
        }

        private File PegarArquivoImagem()
        {
            File diretorio = new File(
                    Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures),
                    "Imagens");

            if (!diretorio.Exists())
            {
                diretorio.Mkdirs();
            }

            File arquivoImagem = new File(diretorio, "MinhaFoto.jpg");

            return arquivoImagem;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            MessagingCenter.Send(ArquivoImagem, "TirarFoto");
        }
    }
}