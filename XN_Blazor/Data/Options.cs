using System;

namespace XN_Blazor.Data
{
    public enum DateOption
    {
        Week,
        Month,
        Year
    }
    public static class BarChartDAC
    {
        public static string[] GetChartX(DateTime start, DateTime end)
        {
            string[] days = new string[(end - start).Days];

            for (int i = 0; i < days.Length; i++)
            {
                days[i] = start.AddDays(i).Day.ToString() + "일";
            }
            return days;
        }
    }

}
