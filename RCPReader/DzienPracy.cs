using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class DzienPracy
    {
        public String KodPracownika;

        public DateTime Data;

        public TimeSpan GodzinaWejscia;

        public TimeSpan GodzinaWyjscia;

        public  void DodajDanePracownika(string[] words)
        {
                this.KodPracownika = words[0];
                DateTime.TryParse(words[1], out this.Data);
                TimeSpan.TryParse(words[2], out this.GodzinaWejscia) ;
                TimeSpan.TryParse(words[3], out this.GodzinaWyjscia);
        }


    }
}
