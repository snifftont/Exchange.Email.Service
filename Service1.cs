using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net;
using System.Configuration;
using System.IO;

namespace emailService
{
    public partial class emailService : ServiceBase
    {
        public emailService()
        {
            InitializeComponent();
              
    //if(!System.Diagnostics.EventLog.SourceExists("emailServiceLog"))
    //    System.Diagnostics.EventLog.CreateEventSource("emailServiceLog", "emailLog");

    //eventLog1.Source = "emailServiceLog";
    //// the event log source by which 

    ////the application is registered on the computer

    //eventLog1.Log = "emailLog";
        }

        protected override void OnStart(string[] args)
        {
            email_timer.Start();
        }

        protected override void OnStop()
        {
            email_timer.Stop();
        }

        private void email_timer_Tick(object sender, EventArgs e)
        {
            send_rquest();
           
        }
       
        private bool send_rquest()
        {
            try
            {
                
                
                string uri = System.Configuration.ConfigurationSettings.AppSettings["root_url"].ToString() + "/dailyemail.aspx?myid=1";
                //HttpWebRequest webrequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
                //HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                //webresponse.Close();
                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(uri);
                stream.Close();
                webClient.Dispose();
            }
            catch (Exception ex)
            {
            }
            return true;

        }
        private bool send_rquest2()
        {
            try
            {
                string uri = System.Configuration.ConfigurationSettings.AppSettings["root_url"].ToString() + "/spam_proc.aspx?myid=1";
                HttpWebRequest webrequest = (HttpWebRequest)System.Net.WebRequest.Create(uri);
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                webresponse.Close();
            }
            catch (Exception ex)
            {
            }
            return true;
        }
    }
}
