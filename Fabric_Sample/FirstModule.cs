using Fabric_Sample.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fabric_Sample
{
    internal class FirstModule
    {
        public FirstModule()
        {
            MessageBox.Show("Module loaded..");
            SerializerSample serializerSample = new SerializerSample();
            serializerSample.SerializeToXmlSample();
        }
    }
}
