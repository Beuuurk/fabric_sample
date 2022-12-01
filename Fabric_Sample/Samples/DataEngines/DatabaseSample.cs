using Fabric.Core.CM;
using Fabric.Data;
using Fabric.Factory;
using Fabric_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabric_Sample.Samples.DataEngines
{
    /*
     * This class illustrates the possibilities of database manipulation. The connection to these databases natively manages the MSSQL and MySQL types.
     * For other type of database, if an ODBC driver exists, it can be used for the connection through the DSN connection name configured in
     * the system's ODBC data sources. Attention, this framework being compiled exclusively in 64 bits, it is imperative that the ODBC configuration is done in
     * the windows 64-bit ODBC data source manager.
     */
    internal class DatabaseSample
    {

        public DatabaseSample() { }

        /*
         * Creates a connection to an MSSQL, My SQL, or any other ODBC compliant database whose data source has been defined
         * in the operating system's ODBC data settings.
         */
        public void CreateMSSqlConnectionSample()
        {
            // Create definition connection for MSSQL database.
            // Encrypted String can be replaced by the directly encrypted password string.
            CMMSSQLDatabaseDefinition mssqlDefinition = DatabaseFactory.CreateMSSQLConnectionDefiniton("instance", "database_name", "foo", new Fabric.Core.Common.EncryptedString("bar"));

            // Create definition connection for MYSQL database.
            // Encrypted String can be replaced by the directly encrypted password string.
            CMMYSQLDatabaseDefinition mysqlDefinition = DatabaseFactory.CreateMYSQLConnectionDefiniton("instance", "database_name", "foo", new Fabric.Core.Common.EncryptedString("bar"));

            // Connect to the MSSQL database.
            IDatabase mssql_db = DatabaseFactory.CreateDatabaseConnection(mssqlDefinition);

            // Connect to the MYSQL database.
            IDatabase mysql_db = DatabaseFactory.CreateDatabaseConnection(mysqlDefinition);

            // Connect to the Database with the DSN name
            IDatabase dsn_db = DatabaseFactory.CreateDatabaseConnection("dsn_name");

            // Creates or access to a FeatureClass in the database and retrieves this same FeatureClass for data manipulation.
            // the overwrite parameter to true means that the FeatureClass will be re-created.
            DatabaseFactory.CreateFeatureClassAsync<DataModel>(mssql_db, true);
        }

        /*
         * Creates a Feature Class and table in the database based on a child Feature Entity data model and provides that same Feature Class for data manipulation.
         */
        public void CreateFeatureClassSample()
        {
            // Create definition connection for MSSQL database.
            // Encrypted String can be replaced by the directly encrypted password string.
            CMMSSQLDatabaseDefinition mssqlDefinition = DatabaseFactory.CreateMSSQLConnectionDefiniton("instance", "database_name", "foo", new Fabric.Core.Common.EncryptedString("bar"));

            // Connect to the MSSQL database.
            IDatabase mssql_db = DatabaseFactory.CreateDatabaseConnection(mssqlDefinition);

            // Creates or access to a FeatureClass in the database and retrieves this same FeatureClass for data manipulation.
            // the overwrite parameter to true means that the FeatureClass will be re-created.
            FeatureClass<DataModel> datas = DatabaseFactory.CreateFeatureClassAsync<DataModel>(mssql_db, true);

            // Creates a table in the database by using its data collection directly.
            // In order for this collection of data to be manipulated, the model which represents it must be annotated by a Feature Definition.
            // If the table does not exist in the database, it will be created.
            // To force the table to be recreated, a kind of reset, apply true to the overwrite parameter. This parameter is not mandatory.
            Features<DataModel> featuresDataModel = mssql_db.GetFeatures<DataModel>(false);
        }

        /*
         * The data of a Feature Class represents the linked table in the database. The example below demonstrates how to add, delete or modify such data.
         * To achieve this,
         */
        public void FeaturesSample()
        {
            // Data Used in FeatureClass.
            DataModel data1 = new DataModel { Name = "foo", Phone = "01234" };
            DataModel data2 = new DataModel { Name = "bar", Phone = "43210" };
            DataModel data3 = new DataModel { Name = "foobar", Phone = "56789" };

            // Ajout des données dans la Feat.

            // Create definition connection for MSSQL database.
            // Encrypted String can be replaced by the directly encrypted password string.
            CMMSSQLDatabaseDefinition mssqlDefinition = DatabaseFactory.CreateMSSQLConnectionDefiniton("instance", "database_name", "foo", new Fabric.Core.Common.EncryptedString("bar"));

            // Connect to the MSSQL database.
            IDatabase mssql_db = DatabaseFactory.CreateDatabaseConnection(mssqlDefinition);

            Features<DataModel> datas = mssql_db.GetFeatures<DataModel>();
            datas.Add(data1);
            datas.Add(data2);
            datas.Add(data3);

            // Adding collection is possible.
            datas.AddRange(new List<DataModel>() { data1, data2, data3 });

            // Editing data.
            DataModel modified_data = datas.FirstOrDefault(x => x.Phone == "01234");
            if (modified_data != null)
                modified_data.Phone = "555-01234";

            // Data deletion.
            DataModel removed_data = datas.FirstOrDefault(x => x.Name == "foobar");
            if (removed_data != null)
                datas.Remove(removed_data);

            // Applying changes to the database.
            datas.ApplyChange();
        }

        /*
         * It is possible to add attribute rules on the data at the time of the chosen action such as addition, deletion or modification.
         */
        public void FeaturesRulesSample()
        {
            // Create definition connection for MSSQL database.
            // Encrypted String can be replaced by the directly encrypted password string.
            CMMSSQLDatabaseDefinition mssqlDefinition = DatabaseFactory.CreateMSSQLConnectionDefiniton("instance", "database_name", "foo", new Fabric.Core.Common.EncryptedString("bar"));

            // Connect to the MSSQL database.
            IDatabase mssql_db = DatabaseFactory.CreateDatabaseConnection(mssqlDefinition);

            // Creates or access to a FeatureClass in the database and retrieves this same FeatureClass for data manipulation.
            // the overwrite parameter to true means that the FeatureClass will be re-created.
            FeatureClass<DataModel> datas = DatabaseFactory.CreateFeatureClassAsync<DataModel>(mssql_db, true);

            // Add rule for the model in FeatureClass.
            datas.RuleManager.AddRule("ToUpperData_At_Insert", RuleType.Insert, (obj) =>
            {
                obj.Name = obj.Name.ToUpper();
            }, "Convert to upper case all the name at insert data.");

            // List all rules.
            ICollection<RuleDefinition<DataModel>> rulesInModel = datas.RuleManager.GetRules();
            StringBuilder listRules = new StringBuilder();
            rulesInModel.ToList().ForEach(x =>
            {
                listRules.AppendLine($"Name: {x.Name}    Type: {x.RuleType.ToString()}    Description: {x.Description}");
            });


        }



    }
}
