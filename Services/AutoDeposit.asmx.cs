using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace OnlineBankingApp.Services
{
    /// <summary>
    /// Summary description for AutoDeposit
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AutoDeposit : System.Web.Services.WebService
    {
        private string dd = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\BankInfo.csv");

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        private string[] fileRepl(List<string[]> logins)
        {
            //put it all back together
            string[] ret = new string[logins.Count()];
            int cnt = 0;
            foreach (string[] line in logins)
            {
                ret[cnt] = string.Join(",", line);
                cnt++;
            }

            return ret;
        }

        [WebMethod]
        public bool updateTransfer(string sndFrom, string sndTo, double amnt) 
        {
            string[] lines = File.ReadAllLines(dd);
            List<string[]> logins = new List<string[]>();
            bool reet = true;

            //Pull all users to select which one we want to edit
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    logins.Add(line.Split(','));
                }
            }

            //For simplicity, we only write to the FIRST element(the test element)
            double tmpTo;
            double tmpFrom;
            Boolean toSavings = false;
            if (sndTo.Equals("Savings"))
            {
                toSavings = true;
                tmpTo = Convert.ToDouble(logins[0][6]);
                tmpFrom = Convert.ToDouble(logins[0][4]);
            }
            else
            {
                toSavings = false;
                tmpTo = Convert.ToDouble(logins[0][4]);
                tmpFrom = Convert.ToDouble(logins[0][6]);
            }

            if (tmpFrom < amnt)
            {
                //StatusMessage.Text = "Insufficient funds in account to transfer!";
                reet = false;
            }
            else
            {
                tmpTo += amnt;
                tmpFrom -= amnt;

                if (toSavings)
                {
                    logins[0][6] = Convert.ToString(tmpTo);
                    logins[0][4] = Convert.ToString(tmpFrom);
                }
                else
                {
                    logins[0][4] = Convert.ToString(tmpTo);
                    logins[0][6] = Convert.ToString(tmpFrom);
                }

                //put it all back together
                string[] ret = fileRepl(logins);

                File.WriteAllLines(dd, ret);



                //StatusMessage.Text = "Funds Sent!";
                reet = true;
            }

            return reet;

        }

        [WebMethod]
        public void updateSavings()
        {
            string[] lines = File.ReadAllLines(dd);
            List<string[]> logins = new List<string[]>();

            //Pull all users to select which one we want to edit
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    logins.Add(line.Split(','));
                }
            }

            //For simplicity, we only write to the FIRST element(the test element)
            double tmp = Convert.ToDouble(logins[0][6]);
            tmp += 100;
            logins[0][6] = Convert.ToString(tmp);

            string[] ret = fileRepl(logins);

            File.WriteAllLines(dd, ret);
        }


    }
}
