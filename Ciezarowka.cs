using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikacja;

namespace Lekcja_3
{
    class Ciezarowka:Samochod
    {
        public Ciezarowka(double masa, double vMax, double zbiornik, string marka,double ladunekMax):base(masa,vMax,zbiornik,marka)
        {
            nazwa = "Samochod Ciezarowy";
            this.ladunekMax = ladunekMax;
        } 
        public double masa_Ladunku, ladunekMax;        
        public void zaladuj(double masa)
        {
            if (masa_Ladunku+masa <= ladunekMax)
            {
                masa_Ladunku += masa;
                this.masa += masa;
            }
            else
            {
                Console.WriteLine("Za duzy ladunek");
            }
        }
        public  void rozladuj(double masa)
        {
            if (masa_Ladunku>masa)
            {
                masa_Ladunku -= masa;
            }
            else
            {
                masa_Ladunku = 0;
            }
        }
    }
}
