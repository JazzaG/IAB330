
using SQLite.Net;

namespace ProjectSalutis.core.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
