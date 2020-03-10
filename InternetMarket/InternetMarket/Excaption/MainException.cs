using System;
using System.Collections.Generic;
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
        public void ExceptionWriter(string exp)
        {
            MainWindow.MessageExp(exp);
            mainWindow.OutExp(exp);
        }

    }
}
