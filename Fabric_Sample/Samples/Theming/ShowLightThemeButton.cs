using Fabric.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fabric_Sample.Samples.Theming
{
    public class ShowLightThemeButton : Button
    {
        /// <summary>
        /// Constructor
        /// Define the behavior of the button and its style.
        /// </summary>
        public ShowLightThemeButton()
        {
            Content = "Light theme";
            Command = new CommandHandler(ButtonCommand);
            Style style = Application.Current.FindResource("Fabric_Button") as Style;
            Style = style;
            Width = 120;
        }

        /// <summary>
        /// Button command.
        /// Change theme to light.
        /// </summary>
        /// <param name="obj"></param>
        private void ButtonCommand(object obj)
        {
            FrameworkApplication.Instance.Theming.ToLight();
        }
    }
}
