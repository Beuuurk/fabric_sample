using Fabric.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fabric_Sample.Samples.DockPaneManagement
{
    public class GetDockPaneInfoButton : Button
    {
        /// <summary>
        /// Constructor
        /// Define the behavior of the button and its style.
        /// </summary>
        public GetDockPaneInfoButton()
        {
            Content = "DockPanes infos";
            Command = new CommandHandler(ButtonCommand);
            Style style = Application.Current.FindResource("Fabric_Button") as Style;
            Style = style;
            Width = 120;
        }

        /// <summary>
        /// Button command.
        /// Lists all information about existing panels.
        /// </summary>
        /// <param name="obj"></param>
        private void ButtonCommand(object obj)
        {
            IDockingManager mgmt = FrameworkApplication.Instance.Docking;
            int dockPaneCount = mgmt.DockPanes.Count;
            StringBuilder infos = new StringBuilder();
            infos.AppendLine($"Count of pane: {dockPaneCount.ToString()}");
            foreach (var x in mgmt.DockPanes)
            {
                infos.AppendLine("");
                infos.AppendLine($"For pane title: {x.Title}");
                infos.AppendLine($"Name: {x.Name}  -  Active: {x.IsActiveDocument}  -  Enabled: {x.IsEnabled}");
            }
            MessageBox.Show(infos.ToString());
        }
    }
}
