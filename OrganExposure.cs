using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public class OrganExposure
    {
        // Nazwa tkanki lub grupy tkanek
        public string TissueName { get; set; }

        // Moc dawki równoważnej [µSv/h]
        public double DoseRate_uSvPerHour { get; set; }

        // Czas ekspozycji [h]
        public double ExposureTime_h { get; set; }

        // Współczynnik wagowy tkanki
        public double TissueWeightingFactor { get; set; }
    }
}
