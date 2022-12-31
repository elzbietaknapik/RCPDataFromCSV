using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp7
{
    public static class WczytajDaneZCSV 
    {
        public static void WygenerujObiektyZplikuCSV(string path, char kodFirmy)
        {
            List<DzienPracy> DzienPracownikaFirmy = new List<DzienPracy>();

            if (kodFirmy == 'A')
                WczytywanieZPlikuCSV1(path, DzienPracownikaFirmy);
            else if (kodFirmy == 'B')            
                WczytywanieZPlikuCSV2(path, DzienPracownikaFirmy);
            
            ListaObiektówDzienPracy.WypiszObiektyListy(DzienPracownikaFirmy);
            Console.WriteLine("Wygenerowano " + DzienPracownikaFirmy.Count() + "obiektów");
        }
 
    public static void WczytywanieZPlikuCSV1( string path, List <DzienPracy> DzienPracownikaFirmy)
    {
            var CSVFile = File.ReadLines(path);

            foreach (var line in CSVFile)
            {
                DzienPracy DzienPracyRCP = new DzienPracy();
                string[] words = line.Split(';');
                DzienPracyRCP.DodajDanePracownika(words);
                DzienPracownikaFirmy.Add(DzienPracyRCP);
            }
        }

    public static void WczytywanieZPlikuCSV2( string path, List<DzienPracy> DzienPracownikaFirmy)

    {          
            var CSVFile = File.ReadLines(path);
            var SplitedArray = CSVFile.Select(a => a.Split(';'));
            var result = SplitedArray.GroupBy(c => new { kodPracownika = c[0], Data = c[1] }).ToList();
            
            foreach (var line in result)
            {                
                DzienPracy DzienPracyRCP = new DzienPracy();
                DzienPracyRCP.KodPracownika = line.Key.kodPracownika;
                DateTime.TryParse(line.Key.Data, out DzienPracyRCP.Data);
               
                var we = line.FirstOrDefault(g => g[3] == "WE");
                var wy = line.FirstOrDefault(g => g[3] == "WY");

                if (we != null && wy != null)
                {
                        TimeSpan.TryParse(we[2].ToString(), out DzienPracyRCP.GodzinaWejscia);
                        TimeSpan.TryParse(wy[2].ToString(), out DzienPracyRCP.GodzinaWyjscia);
                        DzienPracownikaFirmy.Add(DzienPracyRCP);
                }

            }
            ListaObiektówDzienPracy.WypiszObiektyListy(DzienPracownikaFirmy);

        }

}
}

   
