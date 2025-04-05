using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public static class DoseCalculator
    {
        // Obliczenie dawki równoważnej dla danej tkanki
        public static double CalculateEquivalentDose(OrganExposure exposure)
        {
            return exposure.DoseRate_uSvPerHour * exposure.ExposureTime_h;
        }

        // Obliczenie dawki skutecznej dla danej tkanki
        public static double CalculateEffectiveDose(OrganExposure exposure)
        {
            return CalculateEquivalentDose(exposure) * exposure.TissueWeightingFactor;
        }

        // Obliczenie łącznej dawki skutecznej
        public static double CalculateTotalEffectiveDose(List<OrganExposure> exposures)
        {
            return exposures.Sum(e => CalculateEffectiveDose(e));
        }
    }
}
