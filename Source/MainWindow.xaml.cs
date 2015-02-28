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

namespace System_Cleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Are you sure to empty recycle bin?", "empty", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                EmptyBin.EmptyBin.SHEmptyRecycleBin(IntPtr.Zero, null, EmptyBin.EmptyBin.RecycleFlags.SHERB_NOCONFIRMATION);
            }
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("This program brings changes in your register, admin rights are required!", "Amdin Rights", MessageBoxButton.OKCancel, MessageBoxImage.Question)) == MessageBoxResult.Cancel)
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
            if ((MessageBox.Show("The register editor brings changes to your computer and can damage it\n are you sure to continue?", "Sure?", MessageBoxButton.YesNo, MessageBoxImage.Hand)) == MessageBoxResult.Yes)
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
