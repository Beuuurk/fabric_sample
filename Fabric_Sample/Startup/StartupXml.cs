using Fabric.Core;
using Fabric.Factory;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fabric_Sample.Startup
{
    internal class StartupXML
    {
        /// <summary>
        /// Create and launch the application by interpreting the extension.xml construction file present in the project.
        /// The build xml file is defined in the "Build xml file" pages.
        /// </summary>
        /// <param name="args">Parameters passed to the application on startup.</param>
        [STAThread]
        public static void Main(params string[] args)
        {
            try
            {
                IFrameworkApplication frameworkApplication = ApplicationFactory.Create("My fisrt application");
                frameworkApplication.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

    }
}
