using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public static class DaneFirmy
    {
        
        public static void WygenerujDaneDlaFirmy()
        {
            string path = " ";
            while (!File.Exists(path))
            {
                Console.WriteLine("Podaj ścieżkę do pliku: ");
                path = Console.ReadLine();

            }          
                char kodFirmy = ' ';

                Console.WriteLine("Jaka jest struktura pliku? [A/B]");
                Console.WriteLine("A struktura pliku: Kod_pracownika;data;godzina_wejścia;godzina_wyjścia;czas_pracy");
                Console.WriteLine("B struktura pliku: Kod_pracownika;data;godzina;WE/WY (WEjście/WYjście)");
                var KodFirmyWybrany = Console.ReadKey();

                while (KodFirmyWybrany.Key != ConsoleKey.A && KodFirmyWybrany.Key != ConsoleKey.B)
                {
                    Console.WriteLine("Wprowadzony znak nie jest prawidłowy. Dla jakiej firmy chcesz wyświetlić dane? [A/B]");
                    

                    KodFirmyWybrany = Console.ReadKey();
                }

                if (KodFirmyWybrany.Key == ConsoleKey.A)
                {
                    kodFirmy = 'A';
                }
                else if (KodFirmyWybrany.Key == ConsoleKey.B)
                {
                    kodFirmy = 'B';
                }
                WczytajDaneZCSV.WygenerujObiektyZplikuCSV(path, kodFirmy);
              
            
        }


    }
}

