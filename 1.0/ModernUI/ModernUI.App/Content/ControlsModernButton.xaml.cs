using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using ModernUI.Windows.Controls;

namespace ModernUI.App.Content
{
    /// <summary>
    ///     Interaction logic for ControlsModernButton.xaml
    /// </summary>
    public partial class ControlsModernButton : UserControl
    {
        public ControlsModernButton()
        {
            InitializeComponent();

            // find all embedded XAML icon files
            Assembly assembly = GetType().Assembly;
            IEnumerable<string> iconResourceNames = from name in assembly.GetManifestResourceNames()
                where name.StartsWith("ModernUI.App.Assets.appbar.")
                select name;


            foreach (string name in iconResourceNames)
            {
                // load the resource stream
                using (Stream stream = assembly.GetManifestResourceStream(name))
                {
                    // parse the icon data using xml
                    XDocument doc = XDocument.Load(stream);

                    XElement path = doc.Root.Element("{http://schemas.microsoft.com/winfx/2006/xaml/presentation}Path");
                    if (path != null)
                    {
                        string data = (string) path.Attribute("Data");

                        // create a modern button and add it to the button panel
                        ButtonPanel.Children.Add(new ModernButton
                        {
                            IconData = Geometry.Parse(data),
                            Margin = new Thickness(0, 0, 8, 0)
                        });
                    }
                }
            }
        }
    }
}