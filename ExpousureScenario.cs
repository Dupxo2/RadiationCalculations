using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public class ExposureScenario
    {
        // Opis sytuacji ekspozycji
        public string Description { get; set; }

        // Lista napromienionych tkanek wraz z danymi ekspozycji
        public List<OrganExposure> ExposedOrgans { get; set; } = new();

        // Źródło promieniowania
        public RadiationSource Source { get; set; }
    }
}
