using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketMongoServer
{
    class MainException : IException
    {
        public MainException()
        {

        }
        public void ExceptionWriter(string exp)
        {
            MainWindow.MessageExp(exp);
        }
    }
}
