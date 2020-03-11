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
        private InternetMarketEntities internetMarket;
        private List<MailSet> mails;
        private List<SmtpServersSet> servers;
        public MailData()
        {
            internetMarket = new InternetMarketEntities();
        }

        public void SetMail(string email)
        {
            MailSet mail = new MailSet
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

        public void SetMailServer(string[] server)
        {
            List<SmtpServersSet> smtpservers = new List<SmtpServersSet>();
            for (int i = 0; i < server.Length; i++)
            {
                SmtpServersSet smtp = new SmtpServersSet
                {
                    Smtp = server[i]
                };
                smtpservers.Insert(i, smtp);

            }
            internetMarket.SmtpServersSet.AddRange(smtpservers);
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
