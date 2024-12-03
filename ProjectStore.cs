using AutoFixture;
using SRED.IO.Task1.Api.Controllers;

namespace SRED.IO.Task1.Api;

public class ProjectStore
{
    private readonly List<ProjectDto> _projects;

    public ProjectStore()
    {
        var fixture = new Fixture
        {
            RepeatCount = 20
        };
        var count = 0;
        _projects = fixture.CreateMany<ProjectDto>().ToList();
        
        foreach (var projectDto in _projects)
        {
            projectDto.Id = ++count;
            projectDto.Name = $"Project {count}";
            projectDto.CreatedBy = "Abyalew";
            projectDto.CreatedOn = DateTime.UtcNow;
        }
    }
    public List<ProjectDto> GetProjects()
    {
        return _projects;
    }

    public void Add(ProjectDto projectDto)
    {
        _projects.Add(projectDto);
    }

    public void AddRange(IEnumerable<ProjectDto> projectDtos)
    {
        _projects.AddRange(projectDtos);
    }

    public bool Update(ProjectDto projectDto)
    {
        var project = _projects.FirstOrDefault(p => p.Id == projectDto.Id);
        if(project == null)
            return false;
        project.Name = projectDto.Name;
        project.Description = projectDto.Description;
        project.IsIncluded = projectDto.IsIncluded;
        project.IntegrationOf = projectDto.IntegrationOf;
        return true;
    }
}