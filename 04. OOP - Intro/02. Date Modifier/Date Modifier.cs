using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


class Date_Modifier
{
    public Date_Modifier()
    { }

    public double CalculateDays(string date1, string date2)
    {

        DateTime dateStart = DateTime.ParseExact(date1, "yyyy MM dd",CultureInfo.InvariantCulture);
        DateTime dateEnd = DateTime.ParseExact(date2,"yyyy MM dd",CultureInfo.InvariantCulture);

        double difference = (dateEnd - dateStart).TotalDays;
        return difference;
    }
}

