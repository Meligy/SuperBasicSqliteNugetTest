using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;

namespace PlaySqliteNuGet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sessionFactory = ConfigureSessionFactory();
            using(sessionFactory)
            using(sessionFactory.OpenSession())
            {
                Console.WriteLine("Seems SQLite works nicely");
            }
        }

        private static ISessionFactory ConfigureSessionFactory()
        {
            var config = new Configuration();

            config.DataBaseIntegration(db =>
            {
                db.Dialect<SQLiteDialect>();
                db.ConnectionStringName = "Sqlite_InMemory";
            });

            return config.BuildSessionFactory();
        }
    }
}