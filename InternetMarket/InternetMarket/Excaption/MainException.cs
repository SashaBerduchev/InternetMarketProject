using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public class MainException : IException
    {
        private MainWindow mainWindow;
        public MainException(MainWindow win)
        {
              mainWindow = win;
        }
        public void ExceptionWriter(Exception exp)
        {
            MainWindow.MessageExp(exp.ToString());
            mainWindow.OutExp(exp.ToString());
            Trace.WriteLine(exp.StackTrace);
        }

    }
}
