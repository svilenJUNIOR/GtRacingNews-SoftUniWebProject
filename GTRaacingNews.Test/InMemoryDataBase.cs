using GtRacingNews.Data.DBContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace GtRaacingNews.Test
{
    public class InMemoryDataBase
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<SqlDBContext> dbContextOptions;

        public InMemoryDataBase()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<SqlDBContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new SqlDBContext(dbContextOptions);

            context.Database.EnsureCreated();
        }

        public SqlDBContext CreateContext() => new SqlDBContext(dbContextOptions);

        public void Dispose() => connection.Dispose();
    }
}
