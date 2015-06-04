using SQLite;

namespace SyrianPound
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection(); 
    }
}