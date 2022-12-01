using Fabric.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fabric_Sample.Samples.Common
{
    /*
     * Class allowing the execution of method with or without parameters as well as method with return in an entirely asynchronous way in the internal task manager
     * (see Task: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=net-6.0)
     * For convenience, up to 5 different types of parameters are provided and obviously for calls with return, one return type.
     * All methods of this class are static. Queued should therefore not be referenced.
     */
    internal class QueuedSample
    {
        public QueuedSample() { }

        private int Sum(int a, int b)
        {
            return a + b;
        }

        /*
         * Example of an asynchronous method execution with a return value.
         */
        public async void QueuedWithReturnSample()
        {
            int a = 4;
            int b = 6;
            int Sum = await Queued.Run<int>(() =>
            {
                return this.Sum(a, b);
            });
        }

        /*
         * Example of an asynchronous execution of a method without returning a value.
         */
        public async void QueuedWithoutReturnSample()
        {
            int a = 4;
            int b = 6;
            await Queued.Run(() =>
            {
                MessageBox.Show(this.Sum(a, b).ToString());
            });
        }




    }
}
