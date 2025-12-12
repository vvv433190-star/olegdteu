using System;
using System.Collections.Generic;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int _year;
    private int _month;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        List<DateTime> daysOfMonth = new List<DateTime>();
        int daysInMonth = DateTime.DaysInMonth(_year, _month);

        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime date = new DateTime(_year, _month, day);
            if (date.DayOfWeek == dayOfWeek)
            {
                daysOfMonth.Add(date);
            }
        }

        switch (schedule)
        {
            case Schedule.First:
                return daysOfMonth[0];
            case Schedule.Second:
                return daysOfMonth[1];
            case Schedule.Third:
                return daysOfMonth[2];
            case Schedule.Fourth:
                return daysOfMonth[3];
            case Schedule.Last:
                return daysOfMonth[daysOfMonth.Count - 1];
            case Schedule.Teenth:
                foreach (var date in daysOfMonth)
                {
                    if (date.Day >= 13 && date.Day <= 19)
                        return date;
                }
                break;
        }

        throw new InvalidOperationException("No valid date found for given schedule");
    }
}