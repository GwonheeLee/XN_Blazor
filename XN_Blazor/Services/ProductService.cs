using System;

namespace XN_Blazor.Services
{
    public enum DateOption
    {
        Week,
        Month,
        Year
    }
    public static class BarChartService
    {
        public static string[] GetChartX(DateTime start, DateTime end)
        {
            string[] days = new string[(end - start).Days];

            for (int i = 0; i < days.Length; i++)
            {
                days[i] = start.AddDays(i).Day.ToString();
            }
            return days;
        }
        public static double[] GetSeriesData(int x)
        {
            double[] seriesData = new double[x];
            Random random = new Random();
            for (int i = 0;i<x;i++)
            {
                seriesData[i]=random.Next(1,50);
            }
            return seriesData;
        }
    }

    public static class PieChartService
    {
        public static double[] GetDate()
        {
            double[] data = new double[2];
            Random random = new Random();

            int goodProduct = random.Next(30,101);
            int badProduct = 100 - goodProduct;

            data[0] = goodProduct;
            data[1] = badProduct;

            return data;
        }
    }



}
