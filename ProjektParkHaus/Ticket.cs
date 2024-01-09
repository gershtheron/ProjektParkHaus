using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektParkHaus
{
    public partial class Ticket : Form
    {

        private Database db = new Database();
        public Ticket()
        {
            InitializeComponent();
        }


        //LABEL METHODS ____________________________________________________________

        public void SetPrice(int price)
        {
            lbPay.Text = Convert.ToInt32(price).ToString();
        }
        public void SetTickno(int tickno)
        {
            lbTicket.Text = Convert.ToInt32(tickno).ToString();
        }
        //SET LABELS METHOD; INPUT FORM1 --> LABELS TICKET FORM________________________________
        public void SetLabels(string dateIn, string timein, int spot, int exit, int id)
        {
            //lbTicket.Text = Convert.ToInt32(ticketno).ToString();
            lbDatein.Text = dateIn;
            lbTimein.Text = timein;

            // lbTimeout.Text = timeout;

            lbSpotid.Text = Convert.ToInt32(spot).ToString();
            lbTimeout.Text = Convert.ToInt32(exit).ToString();
            lbTicket.Text = Convert.ToInt32(id).ToString();

        }

        //GET RANDOM MONEY IN __________________________________________________________________
        private void GetRandomMoney()
        {
            Random rand = new Random();
            int minMoneyin = 5;
            int maxMoneyin = 100;
            double moneyin = rand.Next(minMoneyin, maxMoneyin + 1);


            if (moneyin >= Convert.ToInt32(lbPay.Text))
            {
                // Calculate the change amount
                double change = moneyin - Convert.ToInt32(lbPay.Text);

                // Display the values in labels
                lblMoneyIn.Text = "Money In: €" + moneyin.ToString("0.00");
                lblOutstandingAmount.Visible = false; // Hide the label
                lblChangeGiven.Text = "Wechselgeld gegeben: €" + change.ToString("0.00");

            }
            else
            {
                // Calculate the remaining amount
                double remainingAmount = Convert.ToInt32(lbPay.Text) - moneyin;

                // Display the values in labels
                lblMoneyIn.Text = "Geld ein: €" + moneyin.ToString("0.00");
                lblOutstandingAmount.Text = "ausstehender Betrag: €" + remainingAmount.ToString("0.00");
                lblOutstandingAmount.Visible = true; // Show the label
                lblChangeGiven.Text = "Wechselgeld gegeben: €0.00";

                MessageBox.Show("Bitte bezahlen €" + remainingAmount.ToString("0.00") + " Um Ihre Zahlung abzuschließen.");

            }

        }

        //PAY BUTTON____________________________________________________

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkOrange;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }

        private int clickCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            clickCount++;

            if (clickCount == 1)
            {
                GetRandomMoney();


            }
            else if (clickCount == 2)
            {
                button1.Visible = false;
                lbBezahlt.Visible = true;

                MessageBox.Show("Vielen Dank für Ihren Besuch! Gute Fahrt!");
                Application.Exit();
            }

        }













































            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void label10_Click(object sender, EventArgs e)
            {

            }


        }
    } 
