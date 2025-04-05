// Program.cs
using RadiationCalculations;
using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==== RADIATION CALCULATIONS ====");

        // User input
        Console.Write("Enter the name of the radiation source: ");
        string sourceName = Console.ReadLine();

        Console.Write("Enter the dose rate [µSv/h]: ");
        double doseRate = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter exposure time [h]: ");
        double exposureTime = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter the distance from source [cm]: ");
        double distance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine("Available radiation types: Gamma, Beta, Alpha, Neutron, XRay");
        Console.Write("Enter radiation type: ");
        string radiationTypeInput = Console.ReadLine();
        RadiationType radiationType;
        if (!Enum.TryParse(radiationTypeInput, true, out radiationType))
        {
            Console.WriteLine("Invalid radiation type. Defaulting to Gamma.");
            radiationType = RadiationType.Gamma;
        }

        // Initialize source
        var source = new RadiationSource
        {
            Name = sourceName,
            DoseRate_uSvPerHour = doseRate,
            ExposureTime_h = exposureTime,
            Distance_cm = distance,
            Type = radiationType
        };

        var tissues = new Tissues();
        var exposures = new List<OrganExposure>();

        Console.Write("Was the whole body exposed? (y/n): ");
        string wholeBody = Console.ReadLine().ToLower();

        if (wholeBody == "y")
        {
            foreach (var entry in tissues.TissueWeightingFactors)
            {
                exposures.Add(new OrganExposure
                {
                    TissueName = entry.Key,
                    DoseRate_uSvPerHour = doseRate,
                    ExposureTime_h = exposureTime,
                    TissueWeightingFactor = entry.Value
                });
            }
        }
        else
        {
            Console.Write("Enter the number of exposed tissues: ");
            string countInput = Console.ReadLine();
            if (!int.TryParse(countInput, out int count) || count <= 0)
            {
                Console.WriteLine("Invalid number. Exiting.");
                return;
            }

            Console.WriteLine("Available tissues (with weighting factors):");
            foreach (var entry in tissues.TissueWeightingFactors)
            {
                Console.WriteLine($" - {entry.Key} ({entry.Value:F2})");
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter tissue name #{i + 1}: ");
                string tissueName = Console.ReadLine();

                if (!tissues.TissueWeightingFactors.ContainsKey(tissueName))
                {
                    Console.WriteLine("Warning: Unknown tissue. Skipping.");
                    continue;
                }

                double weighting = tissues.GetWeightingFactor(tissueName);

                exposures.Add(new OrganExposure
                {
                    TissueName = tissueName,
                    DoseRate_uSvPerHour = doseRate,
                    ExposureTime_h = exposureTime,
                    TissueWeightingFactor = weighting
                });
            }
        }

        // Calculations and results
        Console.WriteLine("\n==== CALCULATION RESULTS ====");
        var result = new EffectiveDoseResult();

        foreach (var organ in exposures)
        {
            double h = DoseCalculator.CalculateEquivalentDose(organ);
            double e = DoseCalculator.CalculateEffectiveDose(organ);
            double d = DoseCalculator.CalculateAbsorbedDose(h, Constants.RadiationWeightingFactors[source.Type]);
            double eAbs = DoseCalculator.CalculateAbsorbedEnergy(d, Constants.StandardBodyMass_kg);
            double q = DoseCalculator.CalculateIonizingCharge(eAbs);

            result.TissueResults.Add((organ.TissueName, h, e));

            Console.WriteLine($"Tissue           : {organ.TissueName}");
            Console.WriteLine($"Equivalent dose  : {h,10:F2} µSv\t({UnitConverter.SievertToRem(h / 1_000_000):F2} mrem)");
            Console.WriteLine($"Effective dose   : {e,10:F2} µSv\t({UnitConverter.SievertToRem(e / 1_000_000):F2} mrem)");
            Console.WriteLine($"Absorbed dose    : {d,10:F6} Gy \t({UnitConverter.GrayToRad(d):F2} rad)");
            Console.WriteLine($"Absorbed energy  : {eAbs,10:F6} J");
            Console.WriteLine($"Ionizing charge  : {q,10:F6} C\n");
        }

        result.TotalEffectiveDose = result.TissueResults.Sum(t => t.E_T);

        Console.WriteLine("==== SUMMARY ====");
        Console.WriteLine($"Total effective dose E: {result.TotalEffectiveDose,10:F2} µSv\t({UnitConverter.SievertToRem(result.TotalEffectiveDose / 1_000_000):F2} mrem)");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}