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
    
}