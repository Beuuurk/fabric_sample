using Fabric.Core;
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
    public class CreateContentPaneButton : Button
    {
        /// <summary>
        /// Constructor
        /// Define the behavior of the button and its style.
        /// </summary>
        public CreateContentPaneButton()
        {
            Content = "Create ContentPane";
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
            ContentPane pane = UIFactory.CreateContentPane<Notepad, NotepadVM>("Content Notepad", (ctrl, vm) =>
            {
                vm.NotepadContent = "Sample content panel. \n\nGenerally, it represents a table of contents, a tree structure, a list of properties...";
            });
            pane.Dock();
        }
    }
}
