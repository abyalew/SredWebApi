using static System.Net.Mime.MediaTypeNames;

namespace SRED.IO.Task1.Api
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }


    public class SimpleObject
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
    }

    public class TimesheetByMonth
    {
        public string Month { get; set; } = "";
        public string CumulativeHours { get; set; } = "";
        public string TootalHours { get; set; } = "";
    }

    public class TimesheetSummary
    {
        public string Title { get; set; } = "";
        public int Value { get; set; }
        public int Status { get; set; }
        public int Percentage { get; set; }
    }

    public class ProjectHour
    {
        public string Name { get; set; } = "";
        public int TotalHours { get; set; }
        public string Color { get; set; } = "";
    }

    public class EmployeeSummary
    {
        public string Name { get; set; } = "";
        public int timesheetExpected { get; set; }
        public int unconfirmedTimesheet { get; set; }
        public int confirmedTimesheet { get; set; } 
        public int missingTimesheet { get; set; }
        public string image { get; set; } = "";
    }

    public class SredSummary
    {
        public string name { get; set; } = "";
        public int trackingScore { get; set; }
        public int expectedHours { get; set; }
        public int workedHours { get; set; }
        public int trackedHours { get; set; }
        public int New { get; set; }
        public int fiber { get; set; }
        public int fdTest { get; set; }
        public int sredHour { get; set; }
        public string image { get; set; } = "";
    }
}
