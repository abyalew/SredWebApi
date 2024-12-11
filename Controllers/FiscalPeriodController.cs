using Microsoft.AspNetCore.Mvc;

namespace SRED.IO.Task1.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FiscalPeriodController : ControllerBase
{
    [HttpGet(Name = "GetFiscalPeriods")]
    public List<FiscalPeriodDto> GetFiscalPeriods()
    {
        return
        [
            new FiscalPeriodDto
            {
                Id = 1,
                Name = "2022",
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 12, 31),
            },
            new FiscalPeriodDto
            {
                Id = 2,
                Name = "2023",
                StartDate = new DateTime(2023, 1, 1),
                EndDate = new DateTime(2023, 12, 31),
            },
            new FiscalPeriodDto
            {
                Id = 3,
                Name = "2024",
                StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 12, 31),
            }
        ];
    }
}