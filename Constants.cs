using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public static class Constants
    {
        // Przykładowe współczynniki wagowe promieniowania
        public static readonly Dictionary<RadiationType, double> RadiationWeightingFactors = new()
    {
        { RadiationType.Gamma, 1.0 },
        { RadiationType.Beta, 1.0 },
        { RadiationType.Alpha, 20.0 },
        { RadiationType.Neutron, 10.0 },
        { RadiationType.XRay, 1.0 },
    };

        // Energia jonizacji w powietrzu [J]
        public const double IonizationEnergy_J = 5.44e-18;

        // Standardowa masa ciała [kg]
        public const double StandardBodyMass_kg = 70.0;
    }
}
