using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System_Cleaner.dialog;
using System_Cleaner.Properties;
using System.Media;

namespace System_Cleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MetroMessageBox mmb;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.lang == "nl-NL")
            {
                mmb = new MetroMessageBox(nl_NL.msgRclBin, "Leegmaken", "YesNo", SystemSounds.Exclamation);
            }
            else if (Properties.Settings.Default.lang == "en-EN")
            {
                mmb = new MetroMessageBox(en_EN.msgRclBin, "Empty", "YesNo", SystemSounds.Exclamation);
            }

            if (mmb.ShowDialog() == true)
            {
                EmptyBin.EmptyBin.SHEmptyRecycleBin(IntPtr.Zero, null, EmptyBin.EmptyBin.RecycleFlags.SHERB_NOCONFIRMATION);
            }
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.lang == "nl-NL")
            {
                mmb = new MetroMessageBox(nl_NL.msgReg, "Administrator", "OK", SystemSounds.Hand);
            }
            else if (Properties.Settings.Default.lang == "en-EN")
            {
                mmb = new MetroMessageBox(en_EN.msgReg, "Admin Rights", "OK", SystemSounds.Hand);
            }

            if (mmb.ShowDialog() == false)
            {
                
            }
            else
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = "startupEditor\\autoruns.exe";
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    proc.StartInfo.Verb = "runas";
                    proc.Start();
                }
                catch
                {

                }
            }            
        }

        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            diskCleanup dc = new diskCleanup();
            dc.ShowDialog();
        }

        private void Tile_Click_3(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.lang == "nl-NL")
            {
                mmb = new MetroMessageBox(nl_NL.msgReg, "Administrator", "OK", SystemSounds.Hand);
            }
            else if (Properties.Settings.Default.lang == "en-EN")
            {
                mmb = new MetroMessageBox(en_EN.msgReg, "Admin Rights", "OK", SystemSounds.Hand);
            }
            
            if (mmb.ShowDialog() == true)
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = "regedit.exe";
                    proc.StartInfo.Verb = "runas";
                    proc.Start();
                }
                catch
                {

                }
            }            
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == true)
            {

            }
        }
    }
}
