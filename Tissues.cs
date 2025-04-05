using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public class Tissues
    {
        // Współczynniki wagowe dla poszczególnych tkanek wg ICRP 103
        public Dictionary<string, double> TissueWeightingFactors { get; set; } = new()
    {
        { "Breasts", 0.12 },
        { "RedBoneMarrow", 0.12 },
        { "Colon", 0.12 },
        { "Lungs", 0.12 },
        { "Stomach", 0.12 },
        { "Other", 0.12 },
        { "Gonads", 0.08 },
        { "UrinaryBladder", 0.04 },
        { "Liver", 0.04 },
        { "Esophagus", 0.04 },
        { "Thyroid", 0.04 },
        { "Skin", 0.01 },
        { "BoneSurface", 0.01 },
        { "SalivaryGlands", 0.01 },
        { "Brain", 0.01 }
    };

        public double GetWeightingFactor(string tissueName)
        {
            return TissueWeightingFactors.TryGetValue(tissueName, out double factor) ? factor : 0.0;
        }
    }
}
