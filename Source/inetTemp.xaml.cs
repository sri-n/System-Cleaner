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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace System_Cleaner
{
    /// <summary>
    /// Interaction logic for inetTemp.xaml
    /// </summary>
    public partial class inetTemp : MetroWindow
    {
        public inetTemp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            doClearTemp(tgl1.IsChecked.Value, tgl2.IsChecked.Value, tgl5.IsChecked.Value, tgl4.IsChecked.Value, tgl3.IsChecked.Value);
            this.DialogResult = true;
        }

        public void doClearTemp(bool doTemp, bool doCookies, bool doPassword, bool doHistory, bool doAutofrm)
        {
            if (doTemp)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "RunDLL32.exe";
                proc.StartInfo.Arguments = " InetCpl.cpl,ClearMyTracksByProcess 8";
                proc.Start();
            }
            if (doCookies)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "RunDLL32.exe";
                proc.StartInfo.Arguments = " InetCpl.cpl,ClearMyTracksByProcess 2";
                proc.Start();
            }
            if (doPassword)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "RunDLL32.exe";
                proc.StartInfo.Arguments = " InetCpl.cpl,ClearMyTracksByProcess 32";
                proc.Start();
            }
            if (doHistory)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "RunDLL32.exe";
                proc.StartInfo.Arguments = " InetCpl.cpl,ClearMyTracksByProcess 1";
                proc.Start();
            }
            if (doAutofrm)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "RunDLL32.exe";
                proc.StartInfo.Arguments = " InetCpl.cpl,ClearMyTracksByProcess 16";
                proc.Start();
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tgl1.IsChecked = Properties.Settings.Default.ieTemp;
            tgl2.IsChecked = Properties.Settings.Default.ieCook;
            tgl3.IsChecked = Properties.Settings.Default.ieAFD;
            tgl4.IsChecked = Properties.Settings.Default.ieHist;
            tgl5.IsChecked = Properties.Settings.Default.iePwd;
        }
    }
}
