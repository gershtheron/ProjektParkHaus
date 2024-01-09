using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektParkHaus
{
    public class Database
    {
        private MySqlConnection con;
        private string connectionString;

        public Database()
        {
            con = new MySqlConnection("SERVER=localhost;UID=root;PASSWORD='root';DATABASE=parkhaus");
        }
        //OpenClose Methods
        private void oeffnen()
        {
            con.Open();
        }
        private void schliessen()
        {
            if (con != null)
                con.Close();
        }


        //ETAGE______________________________________________________________________
        //--GET METHOD 
        public List<Etage> getEtage()
        {
            List<Etage> LiEtage = new List<Etage>();
            oeffnen();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "SELECT * FROM etage;";
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                LiEtage.Add(
                    new Etage(
                       reader.GetInt32(0),  //etage id
                        reader.GetString(1), //etage name
                         reader.GetInt32(2), //spots amount
                          reader.GetInt32(3), //spots open
                           reader.GetInt32(4) //spots closed
                        )
                    );
            }
            schliessen();
            return LiEtage;
        }

        //--SAVE ETAGE METHOD
        public void saveEtage(Etage Eta)
        {

            oeffnen();
            string s = string.Format
               ("INSERT INTO Etage VALUES (NULL, '{0}','{1}','{2}','{3}'  );"
                   , Eta.Etage_name1, Eta.Spots_amount1, Eta.Spots_open1, Eta.Spots_closed1);


            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            com.ExecuteNonQuery();
            Eta.Etage_id1 = (int)com.LastInsertedId;

            schliessen();
        }
        //--DELETE ETAGE FROM DATABASE  
        public void delEtage(int et_id)
        {

            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = "DELETE FROM ETAGE WHERE ET_id = " + et_id + ";";
            com.ExecuteNonQuery();

            schliessen();
        }


        //-SPOT-------------------------------------------------------------------------------
        //--GET METHOD 
        public List<Spot> getSpot()
        {
            List<Spot> LiSpot = new List<Spot>();
            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = "SELECT * FROM spot;";
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                LiSpot.Add(
                    new Spot(
                       reader.GetInt32(0),
                        reader.GetDouble(1),
                         reader.GetString(2),
                         reader.GetInt32(3)

                        )
                    );
            }
            schliessen();
            return LiSpot;
        }

        //--SAVE SPOT METHOD
        public void saveSpot(Spot Spo)
        {

            oeffnen();

            string s = string.Format
            ("INSERT INTO spot VALUES (NULL, '{0}','{1}','{2}'  );"
            , Spo.Price1.ToString().Replace(',', '.'), Spo.Free, Spo.Et_id);


            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            com.ExecuteNonQuery();
            Spo.Spot_id1 = (int)com.LastInsertedId;

            schliessen();
        }
        //--DELETE spot FROM DATABASE  
        public void delSpot(int spot_id)
        {

            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = "DELETE FROM spot WHERE spot_id = " + spot_id + ";";
            com.ExecuteNonQuery();

            schliessen();
        }


        //PARKTICKET --------------------------------------------------------------------              
        //--GET METHOD 
        public List<ParkTicket> getParkTicket()
        {
            List<ParkTicket> LiPat = new List<ParkTicket>();
            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = "SELECT * FROM parkticket;";
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                LiPat.Add(
                    new ParkTicket(
                         reader.GetInt32(0),
                         reader.GetString(1),
                         reader.GetDateTime(2),
                         reader.GetInt32(3),
                         reader.GetDouble(4)

                        //  reader.IsDBNull(5)?DateTime.Now:reader.GetDateTime(5)

                        )
                    );
            }
            schliessen();
            return LiPat;
        }

        //--SAVE ParkingTicket METHOD_________________________________________
        public void saveParkTicket(ParkTicket Pat)
        {

            oeffnen();

            string s = string.Format
            ("INSERT INTO parkticket VALUES (NULL, '{0}','{1}','{2}','{3}'  );"
            , Pat.Auto_reg1,
            Pat.DateIn1.ToString("yyyy-MM-dd HH:mm:ss"),
            Pat.Spot1,
            Pat.Price1);


            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            com.ExecuteNonQuery();
            Pat.ParkTicket_id1 = (int)com.LastInsertedId;

            schliessen();
        }

        //--DELETE ParkingTicket FROM DATABASE  
        public void delParkTicket(int Parkticket_id)
        {

            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = "DELETE FROM Parkticket WHERE parkticket_id = " + Parkticket_id + ";";
            com.ExecuteNonQuery();

            schliessen();
        }



        //MITARBEITER--------------------------------------------------------------------
        //--GET METHOD 
        public List<Mitarbeiter> getMitarbeiter()
        {
            List<Mitarbeiter> LiMitarb = new List<Mitarbeiter>();
            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = "SELECT * FROM mitarbeiter;";
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                LiMitarb.Add(
                    new Mitarbeiter(
                       reader.GetInt32(0),
                        reader.GetString(1),
                          reader.GetString(2)

                        )
                    );
            }
            schliessen();
            return LiMitarb;
        }

        //--SAVE ma METHOD
        public void saveMitarbeiter(Mitarbeiter Mitarb)
        {

            oeffnen();

            string s = string.Format
            ("INSERT INTO Mitarbeiter VALUES (NULL, '{0}','{1}');"
            , Mitarb.Mitarb_name, Mitarb.MaPassword1);


            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            com.ExecuteNonQuery();

            schliessen();
        }
        //--DELETE ma FROM DATABASE  
        public void delMitarbeiter(int ma_id)
        {

            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = "DELETE FROM mitarbeiter WHERE ma_id = " + ma_id + ";";
            com.ExecuteNonQuery();

            schliessen();
        }


        public Mitarbeiter checkMitarbeiter(string mitarb_name, string MaPassword)
        {

            string s = string.Format("select * from mitarbeiter where ma_name = '{0}' and password ='{1}'",
            mitarb_name, MaPassword);

            oeffnen();

            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            MySqlDataReader reader = com.ExecuteReader();

            try
            {
                if
                    (reader.Read())
                {
                    return new Mitarbeiter(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Passwort oder name falsch", "Fehler" + ex.Message);
            }
            finally
            {
                reader.Close();
                schliessen();
            }
            return null;

        }




























































    }
}
