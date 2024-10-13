using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApiUnitTests.Helpers
{
    public class TestDataContextFactory
    {
        public TestDataContextFactory()
        {
            var builder = new DbContextOptionsBuilder<TheBlackbookContext>();
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            builder.UseSqlite(connection);

            using (var ctx = new TheBlackbookContext(builder.Options))
            {
                ctx.Database.EnsureCreated();
            }

            _options = builder.Options;
        }

        private readonly DbContextOptions _options;

        public TheBlackbookContext Create() => new(_options);
    }
}
