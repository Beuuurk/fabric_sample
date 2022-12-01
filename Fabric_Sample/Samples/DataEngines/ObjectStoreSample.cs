using Fabric.Core.Data;
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
     * This class allows the management of data directly on disks without having to load them all into memory.
     */
    internal class ObjectStoreSample
    {
        public ObjectStoreSample() { }

        /*
         * Opening / creating a data file is done very simply by using the 'Create Object Storage Connection' factory.
         */
        public void CreateObjectStoreConnectionSample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");
        }

        /*
         * The example below demonstrates how to gain access to an entity so that you can manipulate data as desired.
         */
        public void GetEntitySample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");
            var dataModelEntity = storage.GetEntity<DataModel>();
        }

        /*
         * To obtain all the information on the entities found in the data file, all you have to do is call
         * to 'Get Entities Info' which will provide a JSON string containing all the parameters of each entity.
         */
        public void GetEntitiesInfoSample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");
            string entitiesInfo = storage.GetEntitiesInfo();
        }

        /*
         * As for the list of entities, it is possible to obtain complete information in JSON format on the data file.
         */
        public void GetStoreInfoSample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");
            string storageInfo = storage.GetStoreInfo();
        }

        /*
         * The example below shows how to be able to import or export data from or to a JSON file.
         * When importing or exporting, this concerns all the complete data of the data file.
         */
        public void ImportExportSample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");

            // Example of exporting data to a JSON file. 
            storage.Export("osexport.json");

            // Example of importing data from a JSON file.
            storage.Import("osexport.json");
        }

        /*
         * It is possible to completely empty a data file in order to be able to start from scratch.
         * To perform this action, just call the 'Drop' command.
         */
        public void DropSample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");
            storage.Drop();
        }

        /*
         * In the name of its use, the data file will grow as additions are made.
         * However, as for a database when deleting data, unnecessary space remains in the data file.
         * In order to recover this space taken unnecessarily by erased data, it is possible to compress the file in order to free
         * this place and reduce the data file.
         */
        public void CompressSample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");
            storage.Compress();
        }

        /*
         * The example below demonstrates how it is possible to manipulate data and update the data file.
         */
        public void ManipulateEntitySample()
        {
            IObjectStore storage = StoreFactory.CreateObjectStorageConnection("osdata.dat");
            var dataModelEntity = storage.GetEntity<DataModel>();

            DataModel data = new DataModel { Name = "Foo", Phone = "0123456789" };

            // Adding data to an entity.
            dataModelEntity.Add(data);

            // Deletion of data in an entity.
            dataModelEntity.Remove(data);

            // Modification of data in an entity.
            // To make this modification, it is necessary to provide a search clause to update the correct data.
            DataModel modifyData = dataModelEntity.Select(x => x.Name == "Foo").FirstOrDefault();
            if (modifyData != null)
            {
                modifyData.Name = "Bar";
                dataModelEntity.Update(modifyData, x => x.Name == "Foo");
            }

        }




    }
}
