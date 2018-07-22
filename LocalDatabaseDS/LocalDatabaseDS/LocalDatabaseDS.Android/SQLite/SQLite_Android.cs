using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LocalDatabaseDS.Droid.SQLite;
using LocalDatabaseDS.SQLite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace LocalDatabaseDS.Droid.SQLite
{
    public class SQLite_Android : ISQLite
    {
        async Task<SQLiteConnection> ISQLite.GetConnection()
        {

            String databaseName = "Company.db3";
            var docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbFile = Path.Combine(docFolder, databaseName); // FILE NAME TO USE WHEN COPIED
            if (!File.Exists(dbFile))
            {
                FileStream writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
                await Forms.Context.Assets.Open(databaseName).CopyToAsync(writeStream);
            }

            var path = dbFile;
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}