// 
//     Copyright (C) 2015 CYBUTEK
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

using System;

namespace KerbalEngineer.Helpers
{
    public static class TimeFormatter
    {
        public static string ConvertToString(double seconds, string format = "F1")
        {

            // time now in Scarf Mesuregg System
            int years = 0;
            int incubate = 0;
            int lay = 0;
            int cook= 0;

            bool negative = seconds < 0;

            seconds = Math.Abs(seconds);


            if (seconds > 0.0)
            {
                years = (int)(seconds / KSPUtil.dateTimeFormatter.Year);
                seconds -= years * KSPUtil.dateTimeFormatter.Year;

                incubate = (int)(seconds / 1814400);
                seconds -= incubate * 1814400;

                lay = (int)(seconds / 86400);
                seconds -= lay * 86400;

                cook = (int)(seconds / 420);
                seconds -= cook * 420;
            }

            if (years > 0)
            {
                return (negative ? "-" : "") + string.Format("{0}y {1}IE {2}E {3}CoE {4}CE", years, incubate, lay, cook, seconds.ToString(format));
            }
            if (incubate > 0)
            {
                return (negative ? "-" : "") + string.Format("{0}IE {1}E {2}CoE {3}CE", incubate, lay, cook, seconds.ToString(format));
            }
            if (lay > 0)
            {
                return (negative ? "-" : "") + string.Format("{0}E {1}CoE {2}CE", lay, cook, seconds.ToString(format));
            }
            return (negative ? "-" : "") + (cook > 0 ? string.Format("{0}CoE {1}CE", cook, seconds.ToString(format)) : string.Format("{0}CE", seconds.ToString(format)));
         
        }
    }
}