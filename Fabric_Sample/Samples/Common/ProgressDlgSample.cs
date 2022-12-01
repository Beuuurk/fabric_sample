using Fabric.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fabric_Sample.Samples.Common
{
    public class ProgressDlgSample
    {
        public ProgressDlgSample()
        {

        }

        /*
         * Create a dialog progress without arguments for the action.
         * 
         * The true parameter indicates whether the process can be stopped.
         */
        public void WithoutArguments()
        {
            UIFactory.ShowProgress("Without args", () =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                }
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                }
            }, true);
        }

        /*
         * Create a dialog progress with arguments for the action.
         * With argument, it is possible to interact with the information display of the dialog box.
         * 
         * The true parameter indicates whether the process can be stopped.
         */
        public void WhithActionBackground()
        {
            UIFactory.ShowProgress("Without args", (s, e) =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    s.ReportProgress(i, $"Count: {i}");
                }
                s.ReportProgress(0, "End of process.");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                }
            }, true);
        }

    }
}
