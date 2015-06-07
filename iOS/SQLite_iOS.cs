using System;
using System.Diagnostics;
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
            Debug.WriteLine("SQLite_iOS: GetConnection...Start");
            const string sqliteFileName = "SyrainPound.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            string localDbPath = Path.Combine(libraryPath, sqliteFileName);
            Debug.WriteLine(string.Format("SQLite_iOS: GetConnection...Path: {0}", localDbPath));
            return new SQLiteAsyncConnection(localDbPath);
        }
    }
}