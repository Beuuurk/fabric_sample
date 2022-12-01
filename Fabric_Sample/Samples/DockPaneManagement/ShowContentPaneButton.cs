using Fabric.Core;
using Fabric.Desktop.DockWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fabric_Sample.Samples.DockPaneManagement
{
    public class ShowContentPaneButton : Button
    {
        /// <summary>
        /// Constructor
        /// Define the behavior of the button and its style.
        /// </summary>
        public ShowContentPaneButton()
        {
            Content = "Show Content Pane";
            Command = new CommandHandler(ButtonCommand);
            Style style = Application.Current.FindResource("Fabric_Button") as Style;
            Style = style;
            Width = 120;
        }

        /// <summary>
        /// Button command.
        /// Get and show the tool pane with title "Content Notepad".
        /// </summary>
        /// <param name="obj"></param>
        private void ButtonCommand(object obj)
        {
            IDockingManager mgmt = FrameworkApplication.Instance.Docking;
            mgmt.ShowPane("Content Notepad");
        }
    }
}
