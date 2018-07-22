using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using LocalDatabaseDS.iOS.SQLite;
using LocalDatabaseDS.SQLite;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace LocalDatabaseDS.iOS.SQLite
{
    public class SQLite_iOS : ISQLite
    {
        public async Task<SQLiteConnection> GetConnection()
        {
            String databaseName = "Company.db3.db";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, databaseName);
            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("MyLite", "db");
                File.Copy(existingDb, path);
            }

            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}