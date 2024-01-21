using Microsoft.Data.Sqlite;

namespace ElectionManagement.API
{
    public class DatabaseContext : IDatabaseContext
    {
        public SqliteConnection DbConnection { get; set; }
        public DatabaseContext()
        {
            using (DbConnection = new SqliteConnection("Data Source=DB/EMS.db")) { }
        }
    }

    public interface IDatabaseContext
    {
        SqliteConnection DbConnection { get; set; }
    }
}
