using Cytel.Top.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cytel.Top.DataAccess
{
    public class DatabaseHandlerFactory
    {
        private string databaseName;

        public DatabaseHandlerFactory(string dbName)
        {
            databaseName = dbName;
        }

        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = null;

            switch (databaseName.ToLower())
            {
                case "SQL":
                    database = new SqlDataAccess("Data Source=JITHENDRANK01;Initial Catalog=CytelPOC;Integrated Security=SSPI;User ID=sa;Password=Emids123;");
                    break;
                case "PostgreSQL":
                    database = new postgreSQLDataAccess("User ID=postgres;Password=Cytel1234;Host=cyteldb.c8owe0hgyui5.ap-south-1.rds.amazonaws.com;Port=5432;Database=CytelPOC;");
                    break;
                //case "system.data.oleDb":
                //    database = new OledbDataAccess(connectionStringSettings.ConnectionString);
                //    break;
                //case "system.data.odbc":
                //    database = new OdbcDataAccess(connectionStringSettings.ConnectionString);
                //    break;
            }

            return database;
        }

        public string GetProviderName()
        {
            return databaseName;
        }
    }
}
