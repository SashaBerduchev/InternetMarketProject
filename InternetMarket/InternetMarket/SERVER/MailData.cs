using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.SERVER
{
    class MailData
    {
        private InternetMarketDateEntities internetMarket;
        private List<Mail> mails;
        public MailData()
        {
            internetMarket = new InternetMarketDateEntities();
        }

        public void SetMail(string email)
        {
            Mail mail = new Mail
            { Email = email};
            Trace.WriteLine(mail);
            internetMarket.MailSet.Add(mail);
            internetMarket.SaveChanges();
        }

        public List<string> GetMails()
        {
            mails = internetMarket.MailSet.ToList();
            List<string> list = mails.Select(x => x.Email).ToList();
            return list;
        }
    }
}
