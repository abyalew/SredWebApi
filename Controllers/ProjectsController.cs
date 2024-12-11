using Microsoft.AspNetCore.Mvc;

namespace SRED.IO.Task1.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectStore _projectStore;

    public ProjectsController(ProjectStore projectStore)
    {
        _projectStore = projectStore;
    }

    
    [HttpGet(Name = "GetProjects")]
    public List<ProjectDto> GetProjects()
    {
        return _projectStore.GetProjects();
    }
    
    [HttpGet(Name = "GetPage")]
    public Page<ProjectDto> GetPage([FromQuery]bool showArchived, [FromQuery] PageParam param)
    {
        return _projectStore.GetPage(showArchived, param);
    }

    [HttpPost]
    public ProjectDto AddProject(ProjectDto projectDto)
    {
        _projectStore.Add(projectDto);
        return projectDto;
    }
    [HttpPost]
    public List<ProjectDto> AddProjects(List<ProjectDto> projectDtos)
    {
        _projectStore.AddRange(projectDtos);
        return projectDtos;
    }
    [HttpPost]
    public IActionResult Update(ProjectDto projectDto)
    {
        var success = _projectStore.Update(projectDto);
        if (success)
        {
            return Ok(projectDto);
        }
        return NotFound("Project not found");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var success = _projectStore.Delete(id);
        if (success)
        {
            return Ok(true);
        }
        return NotFound("Project not found");
    }
    
    [HttpGet]
    public IActionResult Restore(int id)
    {
        var success = _projectStore.Restore(id);
        if (success)
        {
            return Ok(true);
        }
        return NotFound("Project not found");
    }
}

public class FiscalPeriodDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}