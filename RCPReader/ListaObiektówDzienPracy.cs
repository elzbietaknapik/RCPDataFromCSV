using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public static class ListaObiektówDzienPracy
    {
        public static void WypiszObiektyListy(List<DzienPracy> RCPPracownikowList)
        {
            foreach (var el in RCPPracownikowList)
            {
                Console.WriteLine(el.KodPracownika + ' ' + el.Data + ' ' + el.GodzinaWejscia + ' ' + el.GodzinaWyjscia);
            }

        }
    }
}
