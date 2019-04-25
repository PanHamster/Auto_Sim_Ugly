using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lekcja_3;

namespace Aplikacja
{
    class Samochod
    {
        private double v;
        protected double V
        {

            get
            {
                return v;
            }
            set
            {
                if (value>vMax)
                {
                    v = vMax;
                }
                else
                {
                    v = value;
                }
                
            }
        }
        string _nazwa;
        protected string nazwa
        {
            get
            {
                return _nazwa;
            }
            set
            {
                if (value.Length<=30)
                {
                    _nazwa = value;
                }
                else
                {
                    _nazwa = value.Substring(0, 27)+"...";
                }
            }
        }
        //public double Vkmh
        //{
        //    get
        //    {
        //        return V * 3.6;
        //    }
        //}
        protected double s,  a, masa, paliwo, zbiornik, vMax,przebieg;
        private string Marka;
        private string[] status = { "Wyłączony","Włączony"};
        private bool zaplon, silnik, gaz;
        public Samochod(double masa, double vMax, double zbiornik, string marka)
        {
            if (masa > 0)
            {
                this.masa = masa;
            }
            else
            {
                masa = 1;
            }            
            this.vMax = vMax/3.6;
            this.zbiornik = zbiornik;
            this.Marka = marka;
            zaplon = false;
            silnik = false;
            paliwo = 5;
            nazwa = "Samochod osobowy";
        }
        private void zmaianaDrogi(double dt)
        {
            s += v * dt;
        }
        private void warunkiSilnik(double dt)
        {
            if (!zaplon)
            {
                silnik = false;
            }
            if (!silnik && v >= 0.01)
            {
                v -= 0.01;
            }
            if (v < 0.01)
            {
                v = 0;
            }
        }
        public void Dzialaj(double dt)
        {
            zmaianaDrogi(dt);
            warunkiSilnik(dt);
            zmianaPrzyspieszenia(dt);
            spalajPaliwo(dt);
            zmianaPrendkosci(dt);
        }
        public double DajPrendkosc()
        {           
            return v * 3.6;            
        }
        private void zmianaPrendkosci(double dt)
        {
          
            if (v<vMax)
            {
                V += a * dt;
            }
        }

        private void spalajPaliwo(double dt)
        {
            //paliwo--;
        }

        private void zmianaPrzyspieszenia(double dt)
        {
            a = Sila() / masa;
        }
        private double Sila()
        {
            if (gaz)
            {
                return 10000;
            }
            else
            {
                return 0;
            }
        }

        void Zap()
        {
            zaplon = true;
        }
        void Zgas()
        {
            zaplon = false;
        }
        void Silnik()
        {
            if (zaplon && paliwo != 0)
            {
                silnik = true;                
            }
        }
        void tankuj()
        {
            if (paliwo < zbiornik)
            {
                paliwo++;
            }

        }
        void RysInfo()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Marka:{Marka}");
            Console.SetCursorPosition(0, 1);
            Console.Write($"Zapłon:{status[Convert.ToInt16(zaplon)]}");
            Console.SetCursorPosition(0, 2);
            Console.Write($"Silnik:{status[Convert.ToInt16(silnik)]}");
            Console.SetCursorPosition(0, 3);
            Console.Write($"Paliwo:{paliwo} L");
            Console.SetCursorPosition(0, 4);
            Console.Write($"Prędkość:{v*3.6:F3} Km/h");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"Dystans :{s/1000:F3} Km ");
            if (this is Ciezarowka)
            {
                Console.SetCursorPosition(0, 6);
                Console.WriteLine($"Masa Ładunku to:{(this as Ciezarowka).masa_Ladunku}");
                Console.SetCursorPosition(0, 7);
                Console.WriteLine($"Nazwa:{nazwa}");
                //Console.SetCursorPosition(0, 8);
                //Console.WriteLine(Vkmh);
            }
            else
            {
                Console.SetCursorPosition(0, 6);
                Console.WriteLine($"Nazwa:{nazwa}" );
                //Console.SetCursorPosition(0, 7);
                //Console.WriteLine(Vkmh);
            }
            
        }
        void Gaz(bool doDeski)
        {
            //if (silnik && v < vMax)
            //{
            //    v++;
            //}
            if (silnik)
            {
               gaz = doDeski;
            }
            
        }
        void Hamulec()
        {
            if (v>0.5)
            {
                if (silnik)
                {
                    v--;
                }
                else
                    v -= 0.5;
            }
        }
        public void UI()
        {
            var klawisz = new ConsoleKeyInfo();
            while (klawisz.Key != ConsoleKey.Escape)
            {
                if (DajPrendkosc() > vMax*3.6)
                {
                    Gaz(false);
                }
                Dzialaj(0.01);
                RysInfo();                
                Gaz(false);
                if (Console.KeyAvailable)
                {
                    klawisz = Console.ReadKey(true);
                    if (klawisz.Key == ConsoleKey.UpArrow)
                    {
                        Gaz(true);                      
                    }
                    else if (klawisz.Key == ConsoleKey.DownArrow)
                    {
                        Hamulec();
                    }
                    else if (klawisz.Key == ConsoleKey.Divide)
                    {
                        Zap();
                    }
                    else if (klawisz.Key == ConsoleKey.Multiply)
                    {
                        Silnik();
                    }
                    else if (klawisz.Key == ConsoleKey.Subtract)
                    {
                        Zgas();
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Kliknij ENTER aby kontynuować");
                    }
                    else if (klawisz.Key == ConsoleKey.Add)
                    {
                        tankuj();
                    }
                    else if (klawisz.Key == ConsoleKey.R)
                    {
                        if (this is Ciezarowka)
                        {
                            Console.Clear();
                            (this as Ciezarowka).rozladuj(100);
                        }
                        
                    }
                    else if (klawisz.Key == ConsoleKey.F)
                    {
                        if (this is Ciezarowka)
                        {
                            (this as Ciezarowka).zaladuj(100);
                        }
                    }
                }
                System.Threading.Thread.Sleep(10);
            }
        }

    }
    
}
