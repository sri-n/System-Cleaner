using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace System_Cleaner
{
    class Arguments
    {
        public void Argument(string arg)
        {
            if (arg == "/start")
            {
                MainWindow mw = new MainWindow();
                mw.Hide();
                diskCleanup dc = new diskCleanup();
                if (dc.ShowDialog() == true)
                {
                    App.Current.Shutdown();                    
                }
            }
        }
    }
}
