using SQLite;

namespace XamarinApp.Data
{
    public interface ISQLite
    {
        SQLiteConnection PegarConexao();
    }
}
