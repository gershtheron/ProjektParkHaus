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
    public partial class Admin : Form
    {

        private Database db = new Database();//zugriff zum datenbank
        private List<Etage> LiEtage;
        private List<Spot> LiSpot;
        private List<ParkTicket> LiPat;
        private List<Mitarbeiter> LiMitarb;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            EtageAnzeigen();
            tbEtageName.Clear();
            tbEtageName.Clear();
            tbAmountspots.Clear();
            tbSpotsopen.Clear();
            tbSpotsClosed.Clear();

            SpotAnzeigen();

            MitarbeiterAnzeigen();
            tbMAid.Clear();
            tbMAname.Clear();


            ParkTicketAnzeigen();
        }


        //ETAGE_____________________________________________
        //ANZEIGEN () 
        private void EtageAnzeigen()
        {
            LiEtage = db.getEtage();

            foreach (Etage Eta in LiEtage)
            {

                tbEtageName.Text = Eta.Etage_id1.ToString();
                tbEtageName.Text = Eta.Etage_name1;
                tbAmountspots.Text = Eta.Spots_amount1.ToString();
                tbSpotsopen.Text = Eta.Spots_open1.ToString();
                tbSpotsClosed.Text = Eta.Spots_closed1.ToString();

                dgvEtage.Rows.Add(Eta.Etage_id1, Eta.Etage_name1, Eta.Spots_amount1, Eta.Spots_open1, Eta.Spots_closed1);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Etage Eta = new Etage();
            Eta.Etage_id1 = -1;
            Eta.Etage_name1 = tbEtageName.Text;
            Eta.Spots_amount1 = Convert.ToInt32(tbAmountspots.Text);
            Eta.Spots_open1 = Convert.ToInt32(tbSpotsopen.Text);
            Eta.Spots_closed1 = Convert.ToInt32(tbSpotsClosed.Text);

            db.saveEtage(Eta);

            tbE_id.Clear();
            tbEtageName.Clear();
            tbAmountspots.Clear();
            tbSpotsopen.Clear();
            tbSpotsClosed.Clear();
        }
        private void btnEtageDelete_Click(object sender, EventArgs e)
        {
            string et_Id = dgvEtage.CurrentRow.Cells[0].Value.ToString();

            int which = Convert.ToInt32(et_Id);

            db.delEtage(which);

            EtageAnzeigen();
        }

        private void dgvEtage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbE_id.Text = dgvEtage.CurrentRow.Cells[0].Value.ToString();
            tbEtageName.Text = dgvEtage.CurrentRow.Cells[1].Value.ToString();
            tbAmountspots.Text = dgvEtage.CurrentRow.Cells[2].Value.ToString();
            tbSpotsopen.Text = dgvEtage.CurrentRow.Cells[3].Value.ToString();
            tbSpotsClosed.Text = dgvEtage.CurrentRow.Cells[4].Value.ToString();
        }



        //SPOT_____________________________________________
        //ANZEIGEN () 
        private void SpotAnzeigen()
        {
            LiSpot = db.getSpot();

            foreach (Spot Spo in LiSpot)
            {

                tbSpotid.Text = Spo.Spot_id1.ToString();
                tbSpotFree.Text = Spo.Free.ToString();
                tbPrice.Text = Spo.Price1.ToString();
                tbIDetage.Text = Spo.Et_id.ToString();


                dgvSpot.Rows.Add(Spo.Spot_id1, Spo.Price1, Spo.Free, Spo.Et_id);

            }
        }

        private void dgvSpot_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbSpotid.Text = dgvSpot.CurrentRow.Cells[0].Value.ToString();
            tbSpotFree.Text = dgvSpot.CurrentRow.Cells[1].Value.ToString();
            tbPrice.Text = dgvSpot.CurrentRow.Cells[2].Value.ToString();
            tbIDetage.Text = dgvSpot.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnSpotAdd_Click(object sender, EventArgs e)
        {
            Spot spot = new Spot();

            spot.Spot_id1 = -1;

            spot.Free = tbSpotFree.Text;
            spot.Price1 = Convert.ToDouble(tbPrice.Text);
            spot.Et_id = Convert.ToInt32(tbIDetage.Text);

            db.saveSpot(spot);

            tbSpotid.Clear();
            tbSpotFree.Clear();
            tbPrice.Clear();
            tbIDetage.Clear();

            SpotAnzeigen();
        }

        private void btnSpotDelete_Click(object sender, EventArgs e)
        {
            string Spot_Id = dgvSpot.CurrentRow.Cells[0].Value.ToString();

            int which = Convert.ToInt32(Spot_Id);

            db.delSpot(which);

            SpotAnzeigen();
        }


        //PARKTICKET _____________________________________________
        //ANZEIGEN () 
        private void ParkTicketAnzeigen()
        {
            LiPat = db.getParkTicket();

            foreach (ParkTicket Pat in LiPat)
            {
                tbTicketid.Text = Pat.ParkTicket_id1.ToString();
                tbAutoReg.Text = Pat.Auto_reg1.ToString();
                tbDatein.Text = Pat.DateIn1.ToString();
                tbTicketSpotid.Text = Pat.Spot1.ToString();

                dgvTicket.Rows.Add(Pat.ParkTicket_id1, Pat.Auto_reg1, Pat.DateIn1, Pat.Spot1
                );

            }
        }

        private void dgvTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTicketid.Text = dgvTicket.CurrentRow.Cells[0].Value.ToString();
            tbAutoReg.Text = dgvTicket.CurrentRow.Cells[1].Value.ToString();
            tbDatein.Text = dgvTicket.CurrentRow.Cells[2].Value.ToString();

            tbTicketSpotid.Text = dgvTicket.CurrentRow.Cells[3].Value.ToString();
        }
        private void btnParkTicketAdd_Click(object sender, EventArgs e)
        {
            ParkTicket Pat = new ParkTicket();

            Pat.ParkTicket_id1 = -1;

            Pat.Auto_reg1 = tbAutoReg.Text;
            Pat.DateIn1 = Convert.ToDateTime(tbDatein.Text);

            db.saveParkTicket(Pat);

            tbTicketid.Clear();
            tbAutoReg.Clear();
            tbDatein.Clear();
            tbTimein.Clear();
            tbDuration.Clear();
            tbTicketSpotid.Clear();
            tbTicketPricetoPay.Clear();

            ParkTicketAnzeigen();
        }

        private void btnParkTicketDelete_Click(object sender, EventArgs e)
        {
            string ParkTicket_Id = dgvTicket.CurrentRow.Cells[0].Value.ToString();

            int which = Convert.ToInt32(ParkTicket_Id);

            db.delParkTicket(which);

            ParkTicketAnzeigen();
        }



        //MITARBEITER GROUPBOX___________________________________________________

        //ANZEIGEN () 
        private void MitarbeiterAnzeigen()
        {
            LiMitarb = db.getMitarbeiter();

            foreach (Mitarbeiter Mitarb in LiMitarb)
            {

                tbMAid.Text = Mitarb.Mitarb_id.ToString();
                tbMAname.Text = Mitarb.Mitarb_name;

                dgvMitarbeiter.Rows.Add(Mitarb.Mitarb_id, Mitarb.Mitarb_name);

            }
        }
        private void MAsaveBTN_Click(object sender, EventArgs e)
        {
            Mitarbeiter Mitarb = new Mitarbeiter();
            Mitarb.Mitarb_id = -1;
            Mitarb.Mitarb_name = tbMAname.Text;

            Mitarb.MaPassword1 = tbPassword.Text;

            db.saveMitarbeiter(Mitarb);

            tbMAid.Clear();
            tbMAname.Clear();
            tbPassword.Clear();
        }

        private void MAdelBTN_Click(object sender, EventArgs e)
        {
            string ma_Id = dgvMitarbeiter.CurrentRow.Cells[0].Value.ToString();

            int which = Convert.ToInt32(ma_Id);

            db.delMitarbeiter(which);

            MitarbeiterAnzeigen();
        }





























        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnZuruck_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Create or show Form1 (replace Form1 with the actual name of your first form)
            Form1 form1 = new Form1(); // Create an instance of Form1
            form1.Show();
        }

      
    }
}
