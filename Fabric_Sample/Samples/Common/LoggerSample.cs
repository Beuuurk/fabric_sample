using Fabric.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabric_Sample.Samples.Common
{
    /*
     * Information logging class for tracing application flow.
     * It allows the recording of distinct type of information such as debugging, information, warning, or errors.
     * This is a singleton class.
     */
    internal class LoggerSample
    {
        public LoggerSample() { }

        /*
         * Allows you to define where the log file will be located.
         * By default, the location corresponds to that of the running application and the name of the log file is that of the application with the extension '.log'.
         */
        public void SetPathSample()
        {
            Logger.Instance.SetPath(@"c:\\SampleLogger.log");
        }

        /*
         * When calling this method, an entry is made in the log file indicating the date and time of the entry, the type of entry 'debug' and the message indicated.
         * By default, the source of this entry is collected at runtime. It lets you know which method calls it and then saves it with the entry in the log file.
         */
        public void DebugSample()
        {
            Logger.Instance.Debug("Message to log in file.");
            Logger.Instance.Debug("Message to log in file.", "Other_source");
        }

        /*
        * When calling this method, an entry is made in the log file indicating the date and time of the entry, the entry type 'information' and the message indicated.
        * By default, the source of this entry is collected at runtime. It lets you know which method calls it and then saves it with the entry in the log file.
        */
        public void InformationSample()
        {
            Logger.Instance.Info("Message to log in file.");
            Logger.Instance.Info("Message to log in file.", "Other_source");
        }

        /*
        * When calling this method, an entry is made in the log file indicating the date and time of the entry, the type of entry 'Warning' and the message indicated.
        * By default, the source of this entry is collected at runtime. It lets you know which method calls it and then saves it with the entry in the log file.
        */
        public void WarningSample()
        {
            Logger.Instance.Warning("Message to log in file.");
            Logger.Instance.Warning("Message to log in file.", "Other_source");
        }

        /*
        * When calling this method, an entry is made in the log file indicating the date and time of the entry, the type of entry 'Error' and the message indicated.
        * By default, the source of this entry is collected at runtime. It lets you know which method calls it and then saves it with the entry in the log file.
        */
        public void ErrorSample()
        {
            Logger.Instance.Error("Message to log in file.");
            Logger.Instance.Error("Message to log in file.", "Other_source");
        }



    }
}
