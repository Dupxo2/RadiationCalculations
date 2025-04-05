using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public class RadiationSource
    {
        // Nazwa źródła promieniowania
        public string Name { get; set; }

        // Moc dawki równoważnej [µSv/h]
        public double DoseRate_uSvPerHour { get; set; }

        // Odległość od źródła [cm]
        public double Distance_cm { get; set; }

        // Typ promieniowania (np. Gamma, Alfa)
        public RadiationType Type { get; set; }

        // Czas ekspozycji [h]
        public double ExposureTime_h { get; set; }
    }
}
