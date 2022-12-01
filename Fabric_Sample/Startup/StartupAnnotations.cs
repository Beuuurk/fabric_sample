using Fabric.Core;
using Fabric.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabric_Sample.Startup
{
    internal class StartupAnnotations
    {
        /// <summary>
        /// Build and launch the application by scanning the entire assembly for items with build annotations.
        /// Construction annotations are defined in the "Construction Annotations" pages.
        /// </summary>
        /// <param name="args">Parameters passed to the application on startup.</param>
        [STAThread]
        public static void Main(params string[] args)
        {
            IFrameworkApplication frameworkApplication = ApplicationFactory.Create("My fisrt application", true);
            frameworkApplication.Run();
        }
    }
}
