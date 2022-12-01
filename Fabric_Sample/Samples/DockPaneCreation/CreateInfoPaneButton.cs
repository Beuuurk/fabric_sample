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
    public class CreateInfoPaneButton : Button
    {
        /// <summary>
        /// Constructor
        /// Define the behavior of the button and its style.
        /// </summary>
        public CreateInfoPaneButton()
        {
            Content = "Create InfoPane";
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
            InfoPane pane = UIFactory.CreateInfoPane<Notepad, NotepadVM>("Info Notepad", (ctrl, vm) =>
            {
                vm.NotepadContent = "Sample Info panel. \n\nFor information, table display, properties, etc...";
            });
            pane.Dock();
        }
    }
}
