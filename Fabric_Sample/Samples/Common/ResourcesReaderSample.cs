using Fabric.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fabric_Sample.Samples.Common
{
    /*
     * Resource file management class in the project. It allows to change the resource file and to collect the desired resources.
     */
    internal class ResourcesReaderSample
    {
        public ResourcesReaderSample() { }

        /*
         * Allows you to retrieve a resource of a specific type identified by its name.
         */
        public void GetResourceObjectSample()
        {
            IResourcesReader reader = new ResourcesReader();
            string message = reader.GetResourceObject<string>("Hello_Message");

            // a static method call is also possible:
            string messageStatic = ResourcesReader.GetResource<string>("Hello_Message");

        }

        /*
         * Gets the string resource identified by the specified name.
         */
        public void GetStringResourceSample()
        {
            IResourcesReader reader = new ResourcesReader();
            string message = reader.GetStringResource("Hello_Message");

            // a static method call is also possible:
            string messageStatic = ResourcesReader.GetString("Hello_Message");
        }

        /*
         * Gets the resource of type 'System.Windows.Controls.Image' contained in the resource file and identified by its name.
         */
        public void GetImageResourceSample()
        {
            IResourcesReader reader = new ResourcesReader();
            Image image = reader.GetImageResource("Hello_Message");

            // a static method call is also possible:
            Image imageStatic = ResourcesReader.GetImage("Hello_Message");
        }



    }
}
