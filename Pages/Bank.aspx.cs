using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBankingApp.Services;

namespace OnlineBankingApp.Pages
{
    public partial class Bank : System.Web.UI.Page
    {
        private AutoDeposit _depositService;

        protected void Page_Load(object sender, EventArgs e)
        {
            _depositService = new AutoDeposit();
        }
        protected void FndBtn_Click(object sender, EventArgs e)
        {
            string sndF = sndFrom.Text;
            string sndT = sndTo.Text;
            double amnt;


            if (sndF.Equals(sndT))
            {
                StatusMessage.Text = "Please Select 2 different Accounts!";
            }
            else if (string.IsNullOrEmpty(FndTxt.Text))
            {
                StatusMessage.Text = "Please enter an amount to trasnfer!";
            }
            else
            {
                //Call service to deposit
                amnt = Convert.ToDouble(FndTxt.Text);

                bool tmp = _depositService.updateTransfer(sndF, sndT, amnt);

                if (tmp)
                {
                    StatusMessage.Text = "Funds Sent!";
                }
                else
                {
                    StatusMessage.Text = "Insufficient funds in account to transfer!";
                }
            }
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            _depositService.updateSavings();
        }
    }
}