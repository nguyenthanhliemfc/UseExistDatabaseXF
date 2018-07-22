using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using LocalDatabaseDS.SQLite;
using LocalDatabaseDS.UWP.SQLite;
using SQLite;
using Xamarin.Forms;
using Windows.ApplicationModel;

[assembly: Dependency(typeof(SQLite_Uwp))]
namespace LocalDatabaseDS.UWP.SQLite
{
    public class SQLite_Uwp :ISQLite
    {
        public async Task<SQLiteConnection> GetConnection()
        {
            String filename = "Company.db3";
            bool isExisting = false;
            try
            {
                StorageFile storage = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                isExisting = true;
            }
            catch (Exception)
            {
                isExisting = false;
            }
            if (!isExisting)
            {
                StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync(filename);
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder, filename, NameCollisionOption.ReplaceExisting);
            }

            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
