using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public static class WczytajDaneZCSV
    {
        public static void WygenerujObiektyZplikuCSV(string path, char kodFirmy)
        {
 
                var CSVFile = File.ReadLines(path);
             
                if (kodFirmy == 'A')
                {

                    List<DzienPracy> DzienPracownikaFirmyA = new List<DzienPracy>();

                    foreach (var line in CSVFile)
                    {
                        DzienPracy DzienPracyRCP = new DzienPracy();
                        string[] words = line.Split(';');

                        DzienPracyRCP.DodajDanePracownika(words);
                        TimeSpan.TryParse(words[3], out DzienPracyRCP.GodzinaWyjscia);

                        DzienPracownikaFirmyA.Add(DzienPracyRCP);
                    }

                    ListaObiektówDzienPracy.WypiszObiektyListy(DzienPracownikaFirmyA);

                }

                else if (kodFirmy == 'B')
                {
                    List<DzienPracy> DzienPracownikaFirmyB = new List<DzienPracy>();

                    foreach (var line in CSVFile)
                    {

                        string[] words = line.Split(';');
                        if (words[3] == "WE" && !String.IsNullOrEmpty(words[2].ToString()))
                        {
                            DzienPracy DzienPracyRCP = new DzienPracy();

                            DzienPracyRCP.DodajDanePracownika(words);
                            DzienPracownikaFirmyB.Add(DzienPracyRCP);

                        }
                        else if (words[3] == "WY")
                        {
                            if (!String.IsNullOrEmpty(words[2].ToString()))
                            {
                                    DateTime.TryParse(words[1], out DateTime Data);
                                    var Pracownik = DzienPracownikaFirmyB.FirstOrDefault(s => s.KodPracownika == words[0] && s.Data == Data);
                                    if (Pracownik != null)
                                    {
                                        TimeSpan.TryParse(words[2], out Pracownik.GodzinaWyjscia) ;

                                    }
                            }
                        }
                    }
                    ListaObiektówDzienPracy.WypiszObiektyListy(DzienPracownikaFirmyB);
                    
                }

        }
    }
}
