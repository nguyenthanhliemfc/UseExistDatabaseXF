using System.Threading.Tasks;
using SQLite;

namespace LocalDatabaseDS.SQLite
{
    public interface ISQLite
    {
        Task<SQLiteConnection> GetConnection();
    }
}