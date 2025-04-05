using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiationCalculations
{
    public static class UnitConverter
    {
        // µSv <-> mSv
        public static double MicroToMilliSievert(double value) => value / 1000.0;
        public static double MilliToMicroSievert(double value) => value * 1000.0;

        // h <-> min
        public static double HoursToMinutes(double hours) => hours * 60.0;
        public static double MinutesToHours(double minutes) => minutes / 60.0;

        // Gy <-> J/kg
        public static double GrayToJoulePerKg(double gray) => gray; // 1 Gy = 1 J/kg

        // rem <-> Sv (1 Sv = 100 rem)
        public static double RemToSievert(double rem) => rem / 100.0;
        public static double SievertToRem(double sv) => sv * 100.0;

        // rad <-> Gy (1 Gy = 100 rad)
        public static double RadToGray(double rad) => rad / 100.0;
        public static double GrayToRad(double gray) => gray * 100.0;

        // Ci <-> Bq (1 Ci = 3.7 * 10^10 Bq)
        public static double CurieToBecquerel(double ci) => ci * 3.7e10;
        public static double BecquerelToCurie(double bq) => bq / 3.7e10;
    }
}
