using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Configuration;

namespace mantis_tests
{
    public class MantisDB : LinqToDB.Data.DataConnection
    {
        public MantisDB() : base("Mantis")
        {
        }

        public ITable<ProjectData> Projects => GetTable<ProjectData>();
        public ITable<AccountData> Account => GetTable<AccountData>();

        public class ConnectionStringSettings : IConnectionStringSettings
        {
            public string ConnectionString { get; set; }
            public string Name { get; set; }
            public string ProviderName { get; set; }
            public bool IsGlobal => false;
        }

        public class MySettings : ILinqToDBSettings
        {
            public IEnumerable<IDataProviderSettings> DataProviders
            {
                get { yield break; }
            }

            public string DefaultConfiguration => "Mantis";
            public string DefaultDataProvider => ProviderName.MySql;

            public IEnumerable<IConnectionStringSettings> ConnectionStrings
            {
                get
                {
                    yield return
                        new ConnectionStringSettings
                        {
                            Name = "Mantis",
                            ProviderName = "MySql.Data.MySqlClient",
                            ConnectionString =
                                @"Server=192.168.64.2;Port=3306;Database=bugtracker;Uid=evgeniy;Pwd=dodo2015;Allow Zero Datetime = True;Connection Timeout=35"
                        };
                }
            }
        }
    }
}