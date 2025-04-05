using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public class EffectiveDoseResult
    {
        // Lista wyników dla poszczególnych tkanek
        public List<(string Tissue, double H_T, double E_T)> TissueResults { get; set; } = new();

        // Suma całkowitej dawki skutecznej
        public double TotalEffectiveDose { get; set; }
    }
}
