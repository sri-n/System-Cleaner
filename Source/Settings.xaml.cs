using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace System_Cleaner
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : MetroWindow
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.lang == "nl-NL")
            {
                lang.SelectedItem = "Dutch (Nederlands)";
            }
            else
            {
                lang.SelectedItem = "English";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lang.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Dutch (Nederlands)")
            {
                Properties.Settings.Default.lang = "nl-NL";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.lang = "en-EN";
                Properties.Settings.Default.Save();
            }
        }
    }
}
