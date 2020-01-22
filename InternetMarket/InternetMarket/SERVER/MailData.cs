using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.SERVER
{
    class MailData : IDisposable
    {
        private InternetMarketDateEntities internetMarket;
        private List<Mail> mails;
        private List<SmtpServers> servers;
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

        public void SetMailServer(string server)
        {
            SmtpServers servers = new SmtpServers
            {
                Smtp = server
            };
            internetMarket.SmtpServersSet.Add(servers);
            internetMarket.SaveChanges();
        }

        public List<string> GetServers()
        {
            servers = internetMarket.SmtpServersSet.ToList();
            return servers.Select(x => x.Smtp).ToList();
        }
        public void Dispose()
        {
            if(mails != null)
            {
                mails.Clear();
                mails = null;
            }

        }
    }
}
