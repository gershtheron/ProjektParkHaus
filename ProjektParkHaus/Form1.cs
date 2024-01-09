namespace ProjektParkHaus
{
    public partial class Form1 : Form
    {

        private Database db = new Database();//zugriff zum datenbank
        //private List<Auto> LiAuto;
        private List<ParkTicket> LiPat;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ParkticketAnzeigen();
        }

        private int elapsedTime = 0;
        private bool isTimerRunning = false;


        //METHOD RANDOM PARKING SPOT_____________________________________
        private int GetRandomSpotId()
        {
            Random rand = new Random();
            int minSpotId = 1;
            int maxSpotId = 9;
            return rand.Next(minSpotId, maxSpotId + 1);
        }


        //DATETIME PICKER______________________________________________________
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.MinDate = DateTime.Today;

            DateTime selectedDate = dateTimePicker1.Value;

            if (selectedDate > DateTime.Today)
            {             
                btnEnter.Enabled = false;
                btnExit.Enabled = false;
            }
            else
            {              
                btnEnter.Enabled = true;
                btnExit.Enabled = true;
            }
        }




         //TIMER__________________________________________________________
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Display the elapsed time in seconds
            lblTimer.Text = "Time in: " + (elapsedTime / 1000) + " seconds";

            // Update the elapsed time
            elapsedTime += timer1.Interval;
        }



        //ENTER BUTTON_____________________________________________________
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFormAutoReg.Text))
            {
                MessageBox.Show("Please enter Car Registration before entering");
            }
            else if (!isTimerRunning)
            {               
                btnAdmin.Enabled = false;
                btnEnter.Enabled = false;
                btnEnter.BackColor = Color.Gray;

                Form1 newForm1 = new Form1();
                newForm1.Show();

                // Start the timer
                timer1.Start();
                isTimerRunning = true;

                btnRefresh.Enabled = false;
                btnExit.Enabled = true;

                // --- Add Date and time to textbox --
                DateTime selectedDateTime = dateTimePicker1.Value;

                string datePart = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                string timePart = selectedDateTime.ToString("HH:mm:ss");

                // Display the date and time in different TextBox controls
                tbDateIn.Text = datePart;   // Display date (month and day)
                tbTimeIn.Text = timePart;

                //string formattedDateTime = selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                //textBox1.Text = formattedDateTime;

                // -- Randomly allocate a parking spot -- 
                int randomSpotId = GetRandomSpotId();

                tbSpotId.Text = randomSpotId.ToString();

                ParkTicket Pat = new ParkTicket();
                Pat.ParkTicket_id1 = -1;

                Pat.Auto_reg1 = tbFormAutoReg.Text;
                Pat.DateIn1 = Convert.ToDateTime(tbDateIn.Text);
                Pat.Spot1 = Convert.ToInt32(tbSpotId.Text);

                db.saveParkTicket(Pat);

                tbTicketNo.Text = "" + Pat.ParkTicket_id1;

            }
        }


        private void ParkticketAnzeigen()
        {
            LiPat = db.getParkTicket();

            foreach (ParkTicket Pat in LiPat)
            {
               // cbAutoReg.Items.Add(Pat.Auto_reg1);
                //tbMAid.Text = Convert.ToString(Mitarb.Mitarb_id);
            }
        }


        //EXIT BUTTON_______________________________________________________
        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Yellow;
            int totalSeconds = 0;
            if (int.TryParse(tbTotalTime.Text, out totalSeconds)) //1---this here is to parse out the amount of seconds
            {

                if (string.IsNullOrEmpty(tbFormAutoReg.Text))
                {
                    MessageBox.Show("Please enter Car Registration before entering");

                    btnExit.Enabled = false;
                }
                else
                {
                    
                    Ticket newTicket = new Ticket();

                    newTicket.SetLabels
                        (  tbDateIn.Text, 
                           tbTimeIn.Text, 
                           Convert.ToInt32(tbSpotId.Text),
                           Convert.ToInt32(tbTotalTime.Text), 
                           Convert.ToInt32(tbTicketNo.Text)
                        );
                        //--2 we then have to convert to int32                   

                    // Define the price per second for the bay
                    double pricePerSecond = 10.0;                               
                    double totalCost = totalSeconds * pricePerSecond;
                   

                    // Display the total cost in the TotalCost Textbox
                    tbTotalCost.Text = totalCost.ToString();

                    newTicket.SetPrice(Convert.ToInt32(tbTotalCost.Text));

                    Point formPosition = this.Location;
                    newTicket.StartPosition = FormStartPosition.Manual;
                    newTicket.Location = formPosition;
                    newTicket.Show();

                }

            }
            // Stop the timer
            timer1.Stop();
            isTimerRunning = false;


            //----3 and this is the final part of the code to convert the timer digits to string to the lbtotaltime
            // Calculate elapsed time in seconds
            int elapsedSeconds = (int)(elapsedTime / 1000 - 1);

            tbTotalTime.Text = elapsedSeconds.ToString();

            Ticket Ticket = new Ticket();

        }



        //REFRESH BUTTON_______________________________________________________
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newForm = new Form1();
            newForm.Show();
        }

        //ADMIN BUTTON________________________________________________________
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm newLogin = new LoginForm();
            newLogin.Show();
            
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }


}