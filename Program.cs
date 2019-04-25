using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lekcja_3;

namespace Aplikacja
{

    class Program
    {
        static void Start()
        {
            Console.CursorVisible = false;
            string samochody = 
@"Bmw        - Kliknij F1
Volvo      - Kliknij F2
Skoda      - Kliknij F3
Porsche    - Kliknij F4
Alfa Romeo - Kliknij F5
Instrukcja:
'/' - zapłon
'*' - silnik
'-' - zgaszenie zaplonu
Aby wyłączyć symulator kliknij ESCAPE";            
            Samochod Bmw = new Samochod(1200, 180, 60, "Bmw");
            Samochod Volvo = new Samochod(1300, 190, 67, "Volvo");
            Samochod Skoda = new Samochod(1400, 180, 50, "Skoda");
            Samochod Porsche = new Samochod(1100, 200, 70, "Porshe");
            Samochod Alfa_Romeo = new Samochod(1250, 240, 80, "Alfa Romeo");
            Ciezarowka MM = new Ciezarowka(3000, 240, 80, "MM", 1000);
            //Samochod aktywny;       
            var wybor = new ConsoleKeyInfo();
            while (wybor.Key != ConsoleKey.Escape)
            {                
                if (Console.KeyAvailable)
                {                    
                    Console.Clear();
                    Console.WriteLine("Wybierz Samochód");
                    Console.WriteLine(samochody);
                    #region dawniej
                    //wybor = Console.ReadKey(true);
                    //if (wybor.Key == ConsoleKey.F1)
                    //{
                    //    Console.Clear();
                    //    Bmw.UI();

                    //}
                    //else if (wybor.Key == ConsoleKey.F2)
                    //{
                    //    Console.Clear();
                    //    Volvo.UI();

                    //}
                    //else if (wybor.Key == ConsoleKey.F3)
                    //{
                    //    Console.Clear();
                    //    Skoda.UI();
                    //}
                    //else if (wybor.Key == ConsoleKey.F4)
                    //{
                    //    Console.Clear();
                    //    Porsche.UI();
                    //}
                    //else if (wybor.Key == ConsoleKey.F5)
                    //{
                    //    Console.Clear();
                    //    Alfa_Romeo.UI();
                    //}
                    //else if (wybor.Key == ConsoleKey.F6)
                    //{
                    //    Console.Clear();
                    //    MM.UI();
                    //}
                    #endregion 
                    

                }
            }
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
