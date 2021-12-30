using System;

namespace XN_Blazor.Data
{
    public enum DateOption
    {
        Week,
        Month,
        Year
    }
    public static class DateRangeOption
    {
       public static string[] GetWeekDays(DateTime dateTime)
        {
            string[] days = new string[7];

            for(int i = 0; i < days.Length; i++)
            {
                days[i] = dateTime.AddDays(i).Day.ToString()+"일";
            }
            return days;
        }
    }

}
