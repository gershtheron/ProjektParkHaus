using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektParkHaus
{
    public class ParkTicket
    {
        private int ParkTicket_id;
        private string Auto_reg;
        private DateTime DateIn;
        private int Spot;
        private double Price;
        private ParkTicket currentTicket;






        public int ParkTicket_id1 { get => ParkTicket_id; set => ParkTicket_id = value; }
        public string Auto_reg1 { get => Auto_reg; set => Auto_reg = value; }
        public DateTime DateIn1 { get => DateIn; set => DateIn = value; }
        public int Spot1 { get => Spot; set => Spot = value; }
        public double Price1 { get => Price; set => Price = value; }


        public ParkTicket() { }

        public ParkTicket(int PTick_id, string Auto_reg, DateTime date, int Spot, double Price)
        {
            ParkTicket_id = PTick_id;
            this.Auto_reg = Auto_reg;
            DateIn1 = date;
            this.Spot = Spot;
            this.Price1 = Price;










        }

    }
}
