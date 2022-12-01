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
     * The Event Bus class is an event aggregator. This class allows to record and manage unconventional events
     * through all the code of a project. Be careful however, this class must be referenced in a 'root' project visible by any other project in the solution.
     * Generally, the starter project where the referencing of this framework is located is sufficient.
     */
    internal class EventBusSample
    {
        public EventBusSample() { }

        /*
         * Registers an event in the event aggregator. This event is identified by a character string (name).
         * The registration of another action on the same name must be done with the same type of input parameter. Here 'string'.
         * If another event is added with the same name, both actions will be executed when the event is called.
         */
        public void SubscribeSample()
        {
            EventBus bus = new EventBus();
            bus.SubscribeEvent<string>("Sample_Event", (str) =>
            {
                MessageBox.Show(str);
            });
        }

        /*
         * Registers a second action to be executed when the event is called. see 'Subscribe Sample'.
         */
        public void SubscribeAdditionalSample()
        {
            EventBus bus = new EventBus();
            bus.SubscribeEvent<string>("Sample_Event", (str) =>
            {
                MessageBox.Show(str);
            });
            bus.SubscribeEvent<string>("Sample_Event", (str) =>
            {
                MessageBox.Show(str.ToUpper());
            });
        }

        /*
         * Removes the recorded action from the event aggregator that is linked to the given identifier. Here 'Sample Event'.
         * If several actions were recorded, they will all be deleted.
         */
        public void UnsubscribeSample()
        {
            EventBus bus = new EventBus();
            bus.UnsubscribeEvent("Sample_Event");
        }

        /*
         * Sends and executes the event corresponding to the identification.
         * If several actions are recorded on the same identifier, they will all be executed.
         */
        public void SendSample()
        {
            EventBus bus = new EventBus();
            bus.SendEvent<string>("Sample_Event","Hello world !!");
        }

        /*
         * For convenience, this is the static form of the event registration method call. This method follows the same
         * features than the 'Subscribe Event' method of the instantiated class.
         */
        public void SubscribeStaticSample()
        {
            EventBus.Subscribe<string>("Sample_Event", (str) =>
            {
                MessageBox.Show(str);
            });
        }

        /*
         * For convenience, this is the static form of the event suppression method call. This method follows the same
         * Features than the 'A Subscribe Event' method of the instantiated class.
         */
        public void UnsubscribeStaticSample()
        {
            EventBus.Subscribe<string>("Sample_Event", (str) =>
            {
                MessageBox.Show(str);
            });
        }

        /*
         * For convenience, this is the static form of the event execution method call. This method follows the same
         * features than the 'Send Event' method of the instantiated class.
         */
        public void SendStaticSample()
        {
            EventBus.Send<string>("Sample_Event", "Hello world !!");
        }



    }
}
