using System;

namespace KerbalEngineer
{
    public static class EggConverter
    {
        public const string DeltaV = "mr/s"; // he/CoE

        public const double MeterMartenRatio = 0.75;
        public const double MartenEggRatio = 0.1;
        public const double MartenHabitatRatio = 1000.0;
        public const double MartenHiyuRatio = 1000000.0;
        public const double EggFriedEggRatio = 0.1;

        public static double ConvertDeltaV(double deltaV)
        {
            return deltaV / MeterMartenRatio;
        }

        public static float ConvertDeltaV(float deltaV)
        {
            return (float)ConvertDeltaV((double)deltaV);
        }

        public static string ToDistance(double value, int decimals)
        {
            value /= MeterMartenRatio;
            double absolute = Math.Abs(value);

            if(absolute < MartenHiyuRatio)
                return (value / MartenHiyuRatio).ToString("N" + decimals) + "hyu"; // Mega Marten 1000000 mr = 1 hyu = 1 Mmr

            if(absolute >= MartenHabitatRatio)
                return (value / MartenHabitatRatio).ToString("N" + decimals) + "hb"; // Habitat

            if(absolute <= MartenEggRatio)
                return (value / EggFriedEggRatio).ToString("N" + decimals) + "feg"; // Fried egg

            if(absolute <= 1 / MartenEggRatio)
                return (value / MartenEggRatio).ToString("N" + decimals) + "eg"; // Egg

            return value.ToString("N" + decimals) + "mr";
        }
    }
}