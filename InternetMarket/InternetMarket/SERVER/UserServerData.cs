﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class UserServerData : IDisposable
    {
        private InternetMarketDateEntities internetMarket;
        private List<string> passstr;
        private List<string> users;
        public UserServerData()
        {
            users = new List<string>();
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

        public bool CheckUser(string login, string pass)
        {
            try
            {
                passstr = internetMarket.UserSet.Where(x => x.Name.Contains(login)).Select(p => p.Password).ToList();
                if (passstr.Contains(pass))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp);
            }
            return false;
        }
        public bool SetUser(string login, string pass)
        {
            try
            {
                passstr = internetMarket.UserSet.Where(x => x.Name.Contains(login)).Select(p => p.Password).ToList();
                if (passstr.Contains(pass))
                {
                    UserSet users = new UserSet//2
                    {
                        Name = login,//3
                        Password = pass//4
                    };
                    Trace.WriteLine(this);
                    Trace.WriteLine(users);
                    internetMarket.UserSet.Add(users);
                    Trace.WriteLine(internetMarket);
                    internetMarket.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp);
            }
            return false;
        }

        public List<string> GetUsers()
        {
            
            try
            {
                users = internetMarket.UserSet.Select(x => x.Name).ToList();
                return users;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }
        
        public void Remove(string User)
        {
            List<UserSet> users = internetMarket.UserSet.Where(x => x.Name == User).ToList();
            internetMarket.UserSet.Remove(users[1]);
        }
        public void Dispose()
        {
            if(users!=null)users.Clear();
            if(passstr != null)passstr.Clear();
            if(internetMarket !=null)internetMarket.Dispose();
            internetMarket = null;
            passstr = null;
            users = null;
        }
    }
}
