using Android.App;
using Android.Content;
using Android.OS;
using SQLite;
using XamarinApp.Data;
using XamarinApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace XamarinApp.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection PegarConexao()
        {
            return new SQLiteConnection("Agendamento.db3");
        }
    }
}