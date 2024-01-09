using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektParkHaus
{
    public class Etage
    {
        private int Etage_id;
        private string Etage_name;
        private int Spots_amount;
        private int Spots_open;
        private int Spots_closed;

        public Etage() { }

        public Etage(int Eta_id, string Eta_name, int Spot_amt, int Spot_op, int Spot_clo)
        {
            Etage_id = Eta_id;
            Etage_name = Eta_name;
            Spots_amount = Spot_amt;
            Spots_open = Spot_op;
            Spots_closed = Spot_clo;

        }

        public int Etage_id1 { get => Etage_id; set => Etage_id = value; }
        public string Etage_name1 { get => Etage_name; set => Etage_name = value; }
        public int Spots_amount1 { get => Spots_amount; set => Spots_amount = value; }
        public int Spots_open1 { get => Spots_open; set => Spots_open = value; }
        public int Spots_closed1 { get => Spots_closed; set => Spots_closed = value; }





    }
}
