using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Auto
    {
        public Auto(string m, string f, double p)
        {
            SetMarke(m);
            SetFarbe(f);
            SetPreis(p);
        }
        public void SetMarke(string m)
        {
            if (string.IsNullOrWhiteSpace(m)) throw new ArgumentException("Es muss eine Marke angegeben werden!", nameof(m));
            Marke = m;
        }
        public void SetFarbe(string f)
        {
            if (string.IsNullOrWhiteSpace(f)) throw new ArgumentException("Es muss eine Farbe angegeben werden!", nameof(f));
            Farbe = f;
        }
        public void SetPreis(double p)
        {
            if (p < 0) throw new ArgumentException("Der Preis muss positiv sein!", nameof(p));

            if (p >= 0)
                Preis = p;
        }
        public string GetMarke()
        {
            return Marke;
        }
        public string GetFarbe()
        {
            return Farbe;
        }
        public double GetPreis()
        {
            return Preis;
        }

        private string Marke;
        private string Farbe;
        private double Preis;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Auto Obj = new Auto("Tesla","Blau",230.2);

            Console.WriteLine("Marke: {0}, Farbe: {1}, Preis: {2}", Obj.GetMarke(), Obj.GetFarbe(), Obj.GetPreis());

            Obj.SetFarbe("Grün");
            Obj.SetPreis(250.33);

            Console.WriteLine("Marke: {0}, Farbe: {1}, Preis: {2}", Obj.GetMarke(), Obj.GetFarbe(), Obj.GetPreis());
        }
    }
}
