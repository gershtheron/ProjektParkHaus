using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektParkHaus
{
    public class Mitarbeiter
    {
        private int mitarb_id;
        private string mitarb_name;
        private string MaPassword;

        public int Mitarb_id { get => mitarb_id; set => mitarb_id = value; }
        public string Mitarb_name { get => mitarb_name; set => mitarb_name = value; }
        public string MaPassword1 { get => MaPassword; set => MaPassword = value; }


        public Mitarbeiter() { }

        public Mitarbeiter(int ma_id, string ma_name, string pass)
        {
            mitarb_id = ma_id;
            mitarb_name = ma_name;

            MaPassword = pass;

        }

    }
}
