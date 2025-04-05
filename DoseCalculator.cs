using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public static class DoseCalculator
    {
        // H = Ḣ × t – dawka równoważna
        public static double CalculateEquivalentDose(OrganExposure exposure)
        {
            return exposure.DoseRate_uSvPerHour * exposure.ExposureTime_h;
        }

        // E = H × w_T – dawka skuteczna dla jednej tkanki
        public static double CalculateEffectiveDose(OrganExposure exposure)
        {
            double h = CalculateEquivalentDose(exposure);
            return h * exposure.TissueWeightingFactor;
        }

        // Suma wszystkich dawek skutecznych ET
        public static double CalculateTotalEffectiveDose(List<OrganExposure> exposures)
        {
            return exposures.Sum(e => CalculateEffectiveDose(e));
        }

        // D = H / w_R – dawka pochłonięta
        public static double CalculateAbsorbedDose(double equivalentDose, double radiationWeightingFactor)
        {
            return equivalentDose / radiationWeightingFactor;
        }

        // E = D × masa – energia pochłonięta [J]
        public static double CalculateAbsorbedEnergy(double absorbedDose, double tissueMass_kg)
        {
            return absorbedDose * tissueMass_kg;
        }

        // Oszacowanie ładunku jonizującego Q = E / energia jonizacji (w przybliżeniu)
        public static double CalculateIonizingCharge(double absorbedEnergy_J, double ionizationEnergy_J = Constants.IonizationEnergy_J)
        {
            return absorbedEnergy_J / ionizationEnergy_J;
        }
    }
}
