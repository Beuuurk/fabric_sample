using Fabric.Core.Common;
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
     * Memorystore is a class that allows to manage data like a database but with the ease of linq.
     * Data is stored in a file. On connection, all data is read and stored in memory to undergo the desired processing.
     * When saving changes, the data is written to the file.
     * The instantiation of a Memory Store can only be done through the factory Store Factory.
     */
    internal class MemoryStoreSample
    {
        public MemoryStoreSample() { }

        /*
         * Opening / Creating a file with the MemoryStore.
         * With the use of the factory, it is possible to specify whether the file will be secured by encryption or not.
         * By default, the file is secured with AES type data encryption.
         */
        public void OpenMemoryStoreFileSample()
        {
            // Open/Create the secure data file.
            IMemoryStore memoryStoreSecure = StoreFactory.CreateMemoryConnection(@"DataModel.dat");
            // Open/Create the unsecured file.
            IMemoryStore memoryStore = StoreFactory.CreateMemoryConnection(@"DataModel.dat", false);
        }

        /*
         * The example below is used to retrieve an Entity class instance allowing the manipulation of data of the specified type.
         * A class in Titi close the basic operations of contains a collection of objects. It is to be compared to a standard collection of a Specified type.
         */
        public void UseEntityForModelSample()
        {
            IMemoryStore memoryStore = StoreFactory.CreateMemoryConnection(@"DataModel.dat", false);
            Entity<DataModel> dataModel = memoryStore.Get<DataModel>();

            // The line below is a good illustration of adding data to its entity.
            dataModel.Add(new DataModel { Name = "Foo", Phone = "0123456789" });

            // To validate the changes, just run an "ApplyChange()" on the entity. 
            dataModel.ApplyChange();

            // To save data to file. Simply close the MemoryStore with the Close() command.
            // This command has a 'bool' parameter which, if true, will save the modified data to the file.
            // The example below closes the file and saves the changes. 
            memoryStore.Close(true);

            // On the other hand, the example below closes the file without saving any changes.
            memoryStore.Close();

        }





    }
}
