using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class UserServerData
    {
        private InternetMarketDateEntities internetMarket;
        public UserServerData()
        {
            internetMarket = new InternetMarketDateEntities();
        }
        public void SetUserIfApsent()
        {
            try
            {
                Trace.WriteLine(internetMarket.UserSet.Select(x => x.Name).ToList());
                List<string> userSet = internetMarket.UserSet.Select(x => x.Name).ToList();
                if (userSet.Count < 1)
                {
                    UserSet user = new UserSet
                    {
                        Name = "Admin",
                        Password = ""
                    };
                    Trace.WriteLine(user);
                    internetMarket.UserSet.Add(user);
                    Trace.WriteLine(internetMarket);
                    internetMarket.SaveChanges();

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Warning!", MessageBoxButton.OK);
                Trace.WriteLine(e.ToString());
            }
        }
    }
}
