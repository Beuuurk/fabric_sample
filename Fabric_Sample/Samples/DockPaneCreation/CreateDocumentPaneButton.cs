using Fabric.Core;
using Fabric.Core.Extent;
using Fabric.Desktop.DockWpf;
using Fabric.Desktop.DockWpf.Windows.Docking;
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
    public class CreateDocumentPaneButton : Button
    {
        /// <summary>
        /// Constructor
        /// Define the behavior of the button and its style.
        /// </summary>
        public CreateDocumentPaneButton()
        {
            Content = "Create DocumentPane";
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
            DocumentPane pane = UIFactory.CreateDocumentPane<Notepad, NotepadVM>("Document Notepad", (ctrl, vm) =>
            {
                vm.NotepadContent = "Sample Document panel. \n\nHere, we display content, form, etc...";
            });
            pane.Dock();
        }
    }
}
