using Android.App;
using Android.Content.PM;
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
using Android.Net;
using System.Collections.Generic;
using AndroidX.Core.Content;

//Anotação que indica que a classe implementa uma interface dentro do DependencyService
[assembly: Dependency(typeof(MainActivity))]
namespace XamarinApp.Droid
{
    [Activity(Label = "XamarinApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        private const int CAMERA_PERMISSION_REQUEST_CODE = 100;
        private static readonly string[] PermissoesCamera = {
                Manifest.Permission.Camera,
                Manifest.Permission.WriteExternalStorage,
        };
        static File ArquivoImagem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
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

            List<string> permissoesNecessarias = ChecarPermissoes();

            if (activity != null && permissoesNecessarias.Count == 0)
            {
                //Descreve qual ação eu quero fazer
                Intent intent = new Intent(MediaStore.ActionImageCapture);

                ArquivoImagem = PegarArquivoImagem();

                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(ArquivoImagem));

                activity.StartActivityForResult(intent, 1);
            }
            else
            {
                RequisitarPermissoes(permissoesNecessarias);
            }
        }

        private List<string> ChecarPermissoes()
        {
            List<string> permissoesNecessarias = new List<string>();

            foreach (string permissao in PermissoesCamera)
            {
                if (ContextCompat.CheckSelfPermission(Platform.CurrentActivity, permissao) != Permission.Granted)
                {
                    permissoesNecessarias.Add(permissao);
                }
            }

            return permissoesNecessarias;
        }

        private void RequisitarPermissoes(List<string> permissoesNecessarias)
        {
            if(permissoesNecessarias.Count > 0)
            {
                ActivityCompat.RequestPermissions(Platform.CurrentActivity, permissoesNecessarias.ToArray(), CAMERA_PERMISSION_REQUEST_CODE);
            }
        }

        private File PegarArquivoImagem()
        {
            File diretorio = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "Imagens");

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

            if(resultCode == Result.Ok)
            {
                byte[] bytes;

                using (FileInputStream stream = new FileInputStream(ArquivoImagem))
                {
                    bytes = new byte[ArquivoImagem.Length()];
                    stream.Read(bytes);
                }
                    
                MessagingCenter.Send(bytes, "FotoTirada");
            }
        }
    }
}