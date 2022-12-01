using Fabric.Core;
using Fabric.Desktop.DockWpf.Windows.Docking;
using Fabric.Desktop.DockWpf;
using Fabric.Factory;
using Fabric_Sample.UI.ViewModels;
using Fabric_Sample.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fabric_Sample.Samples.DockPaneCreation
{
    public class CreateToolPaneButton : Button
    {
        /// <summary>
        /// Constructor
        /// Define the behavior of the button and its style.
        /// </summary>
        public CreateToolPaneButton()
        {
            Content = "Create ToolPane";
            Command = new CommandHandler(ButtonCommand);
            Style style = Application.Current.FindResource("Fabric_Button") as Style;
            Style = style;
            Width = 120;
        }

        /// <summary>
        /// Button command.
        /// Create the panel using the appropriate factory. This factory follows the MVVM characteristics.
        /// </summary>
        /// <param name="obj"></param>
        private void ButtonCommand(object obj)
        {
            ToolPane pane = UIFactory.CreateToolPane<Notepad, NotepadVM>("Tool Notepad", (ctrl, vm) =>
            {
                vm.NotepadContent = "Sample Tool panel. \n\nGenerally to put a list of additional tools, or other, etc...";
            });
            pane.Dock();
        }
    }
}
