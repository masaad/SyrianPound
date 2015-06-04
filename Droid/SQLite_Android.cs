using System;
using System.IO;
using SQLite;
using SyrianPound.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace SyrianPound.Droid
{
   
    public class SQLite_Android : ISQLite
    {

        public SQLite_Android() { }
        public SQLiteAsyncConnection GetConnection()
        {
            const string sqliteFileName = "SyrianPound.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string localDbPath = Path.Combine(documentsPath, sqliteFileName);
            return new SQLiteAsyncConnection(localDbPath);
        }
    }
}