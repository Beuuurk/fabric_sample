using Fabric.Core.CM;
using Fabric.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Fabric_Sample.Samples.Common
{
    internal class CommandsSample
    {
        public CommandsSample() { }

        /*
         * Defines an example delegate for the methods described below.
         * It is a singleton type class.
         */
        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        /*
         * Defines an example delegate for the methods described below.
         */
        private void ShowHello()
        {
            MessageBox.Show("Hello world !!");
        }

        /*
         * Adds a command in the command handler list with a class definition that indicates characteristics like:
         * - The name.
         * - The UUID identifier.
         * - Its description.
         * - Whether the command can be executed or not.
         */
        public void AddWithDefinition()
        {
            CMCommand command = new CMCommand("Say_Hello1", Guid.NewGuid(), "Say hello in message box", true);
            Commands.Instance.Add(command, ShowHello);
        }

        /*
         * Adds a command to the command handler without populating a definition class. The definition of this
         * order will be added automatically during registration.
         */
        public void AddWithoutDefinition()
        {
            Commands.Instance.Add("Say_Hello2", ShowHello, "Say hello in message box", true);
        }

        /*
         * Adds a command to the command handler without populating a definition class. The definition of this
         * order will be added automatically during registration.
         */
        public void AddWithoutDefinition2()
        {
            Commands.Instance.Add("Say_Hello2", () => { MessageBox.Show("Hello world !!"); }, "Say hello in message box", true);
        }

        /*
         * Adds a command to the command handler without populating a definition class. The definition of this
         * order will be added automatically during registration.
         * This recording is the shortest. 
         * See 'ExecuteCommandWithArg' to see the arguments usage.
         */
        public void AddWithoutDefinitionShortest()
        {
            Commands.Instance.Add("Say_Hello3", ShowMessage);
        }

        /*
         * Adds a command to the command handler without using a definition class but specifying a specific UUID.
         */
        public void AddWithoutdDefinitionButWithId()
        {
            Commands.Instance.Add("Say_Hello4", ShowMessage, Guid.NewGuid());
        }

        /*
         * Executes a saved command without passing parameters to this command.
         */
        public void ExecuteCommand()
        {
            Commands.Instance.Execute("Say_Hello1");
        }

        /*
         * Executes a saved command with the appropriate parameters required by this command.
         */
        public void ExecuteCommandWithArg()
        {
            Commands.Instance.Execute("Say_Hello3", "This is a message.");
        }

        /*
         * Retrieves the saved command by querying the handler.
         */
        public Delegate GetDelegateFromCommandList()
        {
            return Commands.Instance.Get("Say_Hello1");
        }

        /*
         * Provides the list of command definitions registered in the Command Manager.
         */
        public ICollection<CMCommand> GetListCommandDefinition()
        {
            return Commands.Instance.GetDefinitions();
        }

        /*
         * Defines if for a registered command, the execution can be possible or not.
         */
        public void DefineExecution()
        {
            Commands.Instance.SetExecute("Say_Hello1", false);
        }





    }
}
