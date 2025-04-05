using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public class Tissues
    {
        // Lista dostępnych tkanek z ich współczynnikami wagowymi
        public Dictionary<string, double> TissueWeightingFactors { get; set; } = new();

        // Metoda pomocnicza do pobierania współczynnika dla danej tkanki
        public double GetWeightingFactor(string tissueName)
        {
            return TissueWeightingFactors.TryGetValue(tissueName, out double factor) ? factor : 0.0;
        }
    }
}
