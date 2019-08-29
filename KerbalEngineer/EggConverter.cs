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
        public const double EggPancakeRatio = 0.1;

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

            // ordered from longest to shortest
            if (absolute > MartenHiyuRatio)
            {
                return (value / MartenHiyuRatio).ToString("N" + decimals) + "hyu"; // Mega Marten 1000000 mr = 1 hyu = 1 Mmr
            }

            if (absolute > MartenHabitatRatio)
            {
                return (value / MartenHabitatRatio).ToString("N" + decimals) + "hb"; // Habitat
            }

            if (absolute < 1)
            {
                return (value / MartenEggRatio).ToString("N" + decimals) + "eg"; // Egg
            }

            if (absolute / MartenEggRatio < 1)
            {
                return (value / EggPancakeRatio).ToString("N" + decimals) + "pn"; // Pancake
            }


            return value.ToString("N" + decimals) + "mr";
        }

        public static string ToMass(double value, int decimals)
        {
            if (value > 1 * 10e12)
            {
                return value.ToString("e" + decimals + 8) + "at";
            }

            if (value >= 1000.0)
            {
                return value.ToString("N" + decimals + 2) + "at";
            }

            return value.ToString("N" + decimals) + "mt";
        }

        public static string ToMass(double value1, double value2, int decimals = 0)
        {
            if (value1 >= 1000.0f || value2 >= 1000.0f)
            {
                return value1.ToString("N" + decimals + 2) + " / " + value2.ToString("N" + decimals + 2) + "at";
            }
            value1 *= 1000.0;
            value2 *= 1000.0;
            return value1.ToString("N" + decimals) + " / " + value2.ToString("N" + decimals) + "mt";
        }

        public static string ToTemperature(double value)
        {
            // Kelvin to Celcius conversion
            value -= 273.15;

            value = Math.Pow(value * (9.0 / 5) + 32, 1.0 / 3) * Math.Abs(value * (9.0 / 5) + 32);

            return value.ToString("#,0") + "ch";
        }
        public static string ToTemperature(double value1, double value2)
        {
            string a;
            string b;

            a = ToTemperature(value1);
            b = ToTemperature(value2);
            return a.Remove(a.Length - 2) + " / " + b;
        }
    }
}