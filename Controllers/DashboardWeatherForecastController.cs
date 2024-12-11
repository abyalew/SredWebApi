using Microsoft.AspNetCore.Mvc;

namespace SRED.IO.Task1.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public DashboardController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTimesheetStatus")]
        public List<SimpleObject> GetTimesheetStatus([FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            _logger.Log(LogLevel.Debug, "GetTimesheetStatus");
            if (dateFrom == null || dateTo == null)
            {
                return [
                    new SimpleObject
                    {
                        Name = "Total Worked Hours",
                        Value = "600"
                    },
                    new SimpleObject
                    {
                        Name = "Total Tracked Hours",
                        Value = "400"
                    }
                ];
            }
            else
            {
                return [
                    new SimpleObject
                    {
                        Name = "Total Worked Hours",
                        Value = "850"
                    },
                    new SimpleObject
                    {
                        Name = "Total Tracked Hours",
                        Value = "250"
                    }
                ];
            }
        }

        [HttpGet(Name = "GetTimesheetStatusByMonth")]
        public List<TimesheetByMonth> GetTimesheetStatusByMonth()
        {
            return new List<TimesheetByMonth> {
                new TimesheetByMonth {
                    Month= "Jan",
                    CumulativeHours= "500",
                    TootalHours= "55"
                },
                new TimesheetByMonth {
                    Month= "Feb",
                    CumulativeHours= "500",
                    TootalHours= "200"
                },
                new TimesheetByMonth {
                    Month= "Mar",
                    CumulativeHours= "990",
                    TootalHours= "80"
                },
                new TimesheetByMonth {
                    Month= "Apr",
                    CumulativeHours= "700",
                    TootalHours= "280"
                },
                new TimesheetByMonth {
                    Month= "May",
                    CumulativeHours= "500",
                    TootalHours= "200"
                },
                new TimesheetByMonth {
                    Month= "Jun",
                    CumulativeHours= "85",
                    TootalHours= "30"
                },
                new TimesheetByMonth {
                    Month= "Jul",
                    CumulativeHours= "85",
                    TootalHours= "55"
                },
                new TimesheetByMonth {
                    Month= "Aug",
                    CumulativeHours= "500",
                    TootalHours= "55"
                },
                new TimesheetByMonth {
                    Month= "Sep",
                    CumulativeHours= "300",
                    TootalHours= "85"
                }
            };
        }

        [HttpGet(Name = "GetTimesheetSummaries")]
        public List<TimesheetSummary> GetTimesheetSummaries() => [
                new TimesheetSummary
                {
                    Title = "Timesheets Expected",
                    Value = 500,
                    Status = 1,
                    Percentage = 20
                },
                new TimesheetSummary
                {
                    Title = "Timesheets Created",
                    Value = 200,
                    Status = -1,
                    Percentage = 10
                },
                new TimesheetSummary
                {
                    Title = "Timesheets Accepted",
                    Value = 200,
                    Status = 1,
                    Percentage = 20
                },
                new TimesheetSummary
                {
                    Title = "Missing Timesheet",
                    Value = 300,
                    Status = -1,
                    Percentage = 10
                }
            ];

        [HttpGet(Name = "GetProjectHours")]
        public List<ProjectHour> GetProjectHours()
        {
            return new List<ProjectHour>
            {
                new ProjectHour
                {
                    Name = "Apple",
                    TotalHours = 250,
                    Color = "#00A4FF"
                },
                new ProjectHour
                {
                    Name = "Walmart",
                    TotalHours = 600,
                    Color = "#FA6800"
                },
                new ProjectHour
                {
                    Name = "Microsoft",
                    TotalHours = 40,
                    Color = "#AF332D"
                },
                new ProjectHour
                {
                    Name = "Project1",
                    TotalHours = 150,
                    Color = "#3F1EB5"
                },
                new ProjectHour
                {
                    Name = "Project2",
                    TotalHours = 380,
                    Color = "#7555CB"
                },
                new ProjectHour
                {
                    Name = "Project3",
                    TotalHours = 550,
                    Color = "#9A1CCC"
                },
                new ProjectHour
                {
                    Name = "Project4",
                    TotalHours = 180,
                    Color = "#50D9A2"
                },
                new ProjectHour
                {
                    Name = "Project5",
                    TotalHours = 490,
                    Color = "#BF5782"
                },
                new ProjectHour
                {
                    Name = "Project6",
                    TotalHours = 150,
                    Color = "#3C3C3C"
                },
                new ProjectHour
                {
                    Name = "Project7",
                    TotalHours = 35,
                    Color = "#63D11F"
                }
            };
        }

        [HttpGet(Name = "GetEmployeeSummary")]
        public List<EmployeeSummary> GetEmployeeSummary()
        {
            return new List<EmployeeSummary> {
                new EmployeeSummary {
                    Name = "Theresa Webb",
                    timesheetExpected = 54,
                    unconfirmedTimesheet = 21,
                    confirmedTimesheet = 22,
                    missingTimesheet = 11,
                    image = "theresaWebb.png"
                },
                new EmployeeSummary {
                    Name = "Darrell Steward",
                    timesheetExpected = 57,
                    unconfirmedTimesheet = 12,
                    confirmedTimesheet = 33,
                    missingTimesheet = 12,
                    image = "DarrellSteward.png"
                },
                new EmployeeSummary {
                    Name = "Marvin McKinney",
                    timesheetExpected = 99,
                    unconfirmedTimesheet = 34,
                    confirmedTimesheet = 44,
                    missingTimesheet = 21,
                    image = "marvinMcKinney.png"
                },
                new EmployeeSummary {
                    Name = "Brooklyn Simmons",
                    timesheetExpected = 54,
                    unconfirmedTimesheet = 44,
                    confirmedTimesheet = 55,
                    missingTimesheet = 31,
                    image = "brooklynSimmons.png"
                },
                new EmployeeSummary {
                    Name = "Wade Warren",
                    timesheetExpected = 123,
                    unconfirmedTimesheet = 21,
                    confirmedTimesheet = 66,
                    missingTimesheet = 41,
                    image = "marvinMcKinney.png"
                }
            };
        }

        [HttpGet(Name = "GetSredSummary")]
        public List<SredSummary> GetSredSummary()
        {
            return new List<SredSummary>
            {
                new SredSummary {
                    name="Theresa Webb",
                    trackingScore = 70,
                    expectedHours = 120,
                    workedHours = 20,
                    trackedHours = 40,
                    New = 10,
                    fiber = 0,
                    fdTest = 40,
                    sredHour = 40,
                    image = "theresaWebb.png"
                },
                new SredSummary {
                    name="Darrell Steward",
                    trackingScore = 87,
                    expectedHours = 100,
                    workedHours = 10,
                    trackedHours = 55,
                    New = 22,
                    fiber = 0,
                    fdTest = 55,
                    sredHour = 55,
                    image = "DarrellSteward.png"
                },
                new SredSummary {
                    name="Marvin McKinney",
                    trackingScore = 125,
                    expectedHours = 160,
                    workedHours = 60,
                    trackedHours = 10,
                    New = 55,
                    fiber = 0,
                    fdTest = 10,
                    sredHour = 10,
                    image = "marvinMcKinney.png"
                },
                new SredSummary {
                    name="Brooklyn Simmons",
                    trackingScore = 152,
                    expectedHours = 220,
                    workedHours = 20,
                    trackedHours = 70,
                    New = 60,
                    fiber = 0,
                    fdTest = 70,
                    sredHour = 70,
                    image = "brooklynSimmons.png"
                },
                new SredSummary {
                    name="Wade Warren",
                    trackingScore = 95,
                    expectedHours = 120,
                    workedHours = 12,
                    trackedHours = 50,
                    New = 33,
                    fiber = 0,
                    fdTest = 50,
                    sredHour = 50,
                    image = "marvinMcKinney.png"
                }
            };
        }
    }


    public class ProjectDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsIncluded { get; set; }
        public string? IntegrationOf { get; set; }
        public string? Description { get; set; }
        public string? TotalHours { get; set; }
        public string? TimeRecords { get; set; }
        public bool isDeleted { get; set; }
    }
}
