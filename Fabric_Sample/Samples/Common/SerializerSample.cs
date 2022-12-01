using Fabric.Core.Common;
using Fabric_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabric_Sample.Samples.Common
{
    /*
     * Class allowing class serialization or deserialization using JSON or XML format.     
     */
    internal class SerializerSample
    {
        public DataModel Data { get; set; }

        private string _serializedJsonDataModel = "{\"Name\":\"Foo\",\"Phone\":\"0123456789\"}";
        private string _serializedXmlDataModel = "";

        public SerializerSample() { }

        /*
         * Serialize a class to a character string in JSON format.
         */
        public void SerializeToJsonSample()
        {
            Data = new DataModel { Name = "Foo", Phone = "0123456789" };
            Serializer serializer = new Serializer();
            string serializedData = serializer.SerializeJSON<DataModel>(Data);

            // a static method call is also possible:
            string serializedDataStatic = Serializer.ToJson<DataModel>(Data);
        }

        /*
         * Deserialize a character string in JSON format into a class of the specified type.
         */
        public void DeserializeFromJsonSample()
        {
            Serializer serializer = new Serializer();
            DataModel deserializedData = serializer.DeserializeJSON<DataModel>(_serializedJsonDataModel);
            
            // a static method call is also possible:
            DataModel deserializedDataStatic = Serializer.FromJson<DataModel>(_serializedJsonDataModel);
        }

        /*
         * Serialize a class to a character string in XML format.
         */
        public void SerializeToXmlSample()
        {
            Data = new DataModel { Name = "Foo", Phone = "0123456789" };
            Serializer serializer = new Serializer();
            string serializedData = serializer.SerializeXML<DataModel>(Data);

            // a static method call is also possible:
            string serializedDataStatic = Serializer.ToXML<DataModel>(Data);
        }

        /*
         * Deserialize a character string in XML format in class of the specified type.
         */
        public void DeserializeFromXmlSample()
        {
            Serializer serializer = new Serializer();
            DataModel deserializedData = serializer.DeserializeXML<DataModel>(_serializedJsonDataModel);

            // a static method call is also possible:
            DataModel deserializedDataStatic = Serializer.FromXML<DataModel>(_serializedJsonDataModel);
        }




    }
}
