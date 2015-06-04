using System;
using System.IO;
using SQLite;
using SyrianPound.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace SyrianPound.iOS
{   
    public class SQLite_iOS : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            const string sqliteFileName = "SyrainPound.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            string localDbPath = Path.Combine(libraryPath, sqliteFileName);
            return new SQLiteAsyncConnection(localDbPath);
        }
    }
}