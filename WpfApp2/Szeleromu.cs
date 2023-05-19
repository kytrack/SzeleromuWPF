using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Szeleromu
    {
        string helyszin;
        int egyseg;
        int teljesitmeny;
        int evjarat;

        public Szeleromu(string helyszin, int egyseg, int teljesitmeny, int evjarat)
        {
            this.helyszin = helyszin;
            this.egyseg = egyseg;
            this.teljesitmeny = teljesitmeny;
            this.evjarat = evjarat;
        }

        public string Helyszin { get => helyszin; set => helyszin = value; }
        public int Egyseg { get => egyseg; set => egyseg = value; }
        public int Teljesitmeny { get => teljesitmeny; set => teljesitmeny = value; }
        public int Evjarat { get => evjarat; set => evjarat = value; }


        public char Kategorizalas()
        {
            if (Teljesitmeny>999)
            {
                return 'A';
            }
            else if (1000>Teljesitmeny&& Teljesitmeny > 500)
            {
                return 'B';
            }
            else
            {
                return 'C';
            }
        }
    }
}
