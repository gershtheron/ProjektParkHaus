using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektParkHaus
{
    public class Spot
    {
        private int Spot_id;
        private double Price;
        private string free;
        private int et_id;

        public int Spot_id1 { get => Spot_id; set => Spot_id = value; }

        public double Price1 { get => Price; set => Price = value; }
        public string Free { get => free; set => free = value; }
        public int Et_id { get => et_id; set => et_id = value; }

        public Spot() { }

        public Spot(int sp_id, double Price, string free, int et_id)
        {
            Spot_id = sp_id;

            this.Price = Price;
            this.Free = free;
            this.Et_id = et_id;



        }

    }
}
