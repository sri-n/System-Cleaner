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
using System.IO;
using System.Diagnostics;

namespace System_Cleaner
{
    /// <summary>
    /// Interaction logic for diskCleanup.xaml
    /// </summary>
    public partial class diskCleanup : MetroWindow
    {
        public bool doTemp;
        public bool doInterTemp;
        public bool doReclBin;
        public bool doC1;
        public bool doC2;
        public bool doC3;
        
        public diskCleanup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tgl1.IsChecked.Value)
            {
                doTemp = true;
            }
            else
            {
                doTemp = false;
            }

            if (tgl2.IsChecked.Value)
            {
                doReclBin = true;
            }
            else
            {
                doReclBin = false;
            }

            if (tgl3.IsChecked.Value)
            {
                doInterTemp = true;
            }
            else
            {
                doInterTemp = false;
            }

            if (tglC1.IsChecked.Value)
            {
                doC1 = true;
            }
            else
            {
                doC1 = false;
            }

            if (tglC2.IsChecked.Value)
            {
                doC2 = true;
            }
            else
            {
                doC2 = false;
            }

            if (tglC3.IsChecked.Value)
            {
                doC3 = true;
            }
            else
            {
                doC3 = false;
            }
            doClean(doTemp, doReclBin, doInterTemp);            
        }

        public void doClean(bool temp, bool reclbin, bool intertemp)
        {
            txtState.Text = "Please Wait...";
            txtState.Text += "\n";
            if (temp)
            {
                string tempfolder = System.IO.Path.GetTempPath();
                string[] folder = Directory.GetDirectories(tempfolder);
                string[] files = Directory.GetFiles(tempfolder);
                
                txtState.Text += "Starting deleting temp...\n";
                for (int i = 0; i < folder.Length; i++)
                {
                    try
                    {
                        Directory.Delete(folder[i], true);
                        txtState.Text += "Delete folder " + i.ToString() + "\n";
                        txtState.ScrollToEnd();
                    }
                    catch
                    {
                        txtState.Text += "Unable to delete folder " + i.ToString() + "\nTry to start the application as Admin\n";
                        txtState.ScrollToEnd();
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        File.Delete(files[i]);
                        txtState.Text += "Delete file " + i.ToString() + "\n";
                        txtState.ScrollToEnd();
                    }
                    catch
                    {
                        txtState.Text += "Unable to delete file " + i.ToString() + "\nTry to start the application as Admin\n";
                        txtState.ScrollToEnd();
                    }
                }
                txtState.Text += "Temp delete finished...\n";
                txtState.ScrollToEnd();
            }
            if (reclbin)
            {
                txtState.Text += "Starting Emptying Recycle Bin...\n";
                txtState.ScrollToEnd();
                EmptyBin.EmptyBin.SHEmptyRecycleBin(IntPtr.Zero, null, EmptyBin.EmptyBin.RecycleFlags.SHERB_NOCONFIRMATION);
                txtState.Text += "Emptying Recycle Bin finished...\n";
                txtState.ScrollToEnd();
            }
            if (intertemp)
            {
                txtState.Text += "Start Inet Temp Files...\n";
                txtState.ScrollToEnd();
                inetTemp it = new inetTemp();
                if (it.ShowDialog() == true)
                {
                    txtState.Text += "Delete Inet Temp Files finished...\n";
                    txtState.ScrollToEnd();
                }
            }
            if (doC1 || doC2 || doC3)
            {
                doCClean(doC1, doC2, doC3);
            }            
            txtState.Text += "\nDisk Cleanup Finished at " + DateTime.Now.ToString();
            txtState.ScrollToEnd();
        }

        public void doCClean(bool cookies, bool history, bool temp)
        {
            txtState.Text += "Start clearing chrome temp data...\n";
            txtState.ScrollToEnd();
            if (Directory.Exists("C:\\users\\" + Environment.UserName + "\\Appdata\\Local\\Google\\Chrome\\User Data\\Default"))
            {
                if ((MessageBox.Show("To clear chrome cache and temp data, chrome must be closed!\nAre you sure to continue?", "Close", MessageBoxButton.YesNoCancel, MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {
                    if (cookies)
                    {
                        string chromedir = "C:\\users\\" + Environment.UserName + "\\Appdata\\Local\\Google\\Chrome\\User Data\\Default";
                        string[] files = Directory.GetFiles(chromedir, "*Cookies*.*");
                        for (int i = 0; i <= files.Length; i++)
                        {
                            File.Delete(files[i]);
                        }
                    }
                    if (history)
                    {
                        string chromedir = "C:\\users\\" + Environment.UserName + "\\Appdata\\Local\\Google\\Chrome\\User Data\\Default";
                        string[] files = Directory.GetFiles(chromedir, "*History*.*");
                        for (int i = 0; i <= files.Length; i++)
                        {
                            File.Delete(files[i]);
                        }
                    }
                    if (temp)
                    {
                        string chromedir = "C:\\users\\" + Environment.UserName + "\\Appdata\\Local\\Google\\Chrome\\User Data\\Default";
                        string[] files = Directory.GetFiles(chromedir, "*.*");
                        for (int i = 0; i <= files.Length; i++)
                        {
                            File.Delete(files[i]);
                        }
                    }
                    txtState.Text += "Clearing chrome temp data finished...\n";
                    txtState.ScrollToEnd();
                }
            }
            else
            {
                txtState.Text += "Error: can't find chrome dir!!\nIs chrome installed?\n";
                txtState.Text += "Clearing chrome temp data finished with errors!\n";
                txtState.ScrollToEnd();
                MessageBox.Show("Can't find chrome dir!!", "Chrome error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tgl1.IsChecked = Properties.Settings.Default.iexplorer;
            tgl2.IsChecked = Properties.Settings.Default.tempsysfiles;
            tgl3.IsChecked = Properties.Settings.Default.reclbin;
            tglC1.IsChecked = Properties.Settings.Default.ChrCookies;
            tglC2.IsChecked = Properties.Settings.Default.ChrHist;
            tglC3.IsChecked = Properties.Settings.Default.ChrTemp;
        }

        private void tgl3_IsCheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.iexplorer = tgl3.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void tgl1_IsCheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.tempsysfiles = tgl1.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void tgl2_IsCheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.reclbin = tgl2.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void tglC1_IsCheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ChrCookies = tglC1.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void tglC2_IsCheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ChrHist = tglC1.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void tglC3_IsCheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ChrTemp = tglC1.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
