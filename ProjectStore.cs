using System.Reflection;
using AutoFixture;
using Newtonsoft.Json;
using SRED.IO.Task1.Api.Controllers;

namespace SRED.IO.Task1.Api;

public class ProjectStore
{
    private readonly List<ProjectDto> _projects;

    public ProjectStore()
    {
        var fixture = new Fixture
        {
            RepeatCount = 92
        };
        var count = 0;
        var deleteStatus = true;
        _projects = fixture.CreateMany<ProjectDto>().ToList();
        
        foreach (var projectDto in _projects)
        {
            projectDto.Id = ++count;
            projectDto.Name = $"Project {count}";
            projectDto.CreatedBy = "Abyalew";
            projectDto.CreatedOn = DateTime.UtcNow;
            projectDto.isDeleted = deleteStatus;
            deleteStatus = !deleteStatus;
        }
    }
    public List<ProjectDto> GetProjects()
    {
        return _projects;
    }
    public Page<ProjectDto> GetPage(bool showArchived,  PageParam param)
    {
        var filters = JsonConvert.DeserializeObject<List<FilterColumn>>(param.Filters) ?? new List<FilterColumn>();
        var data = _projects.Where(p=>  (showArchived || !p.isDeleted)  && (filters.Count == 0 || filters.Any(f=> ApplyFilter(p, f))))
                                         .Skip((param.CurrentPage - 1) * param.PageSize).Take(param.PageSize).ToList();
        return new Page<ProjectDto>
        {
            TotalPage = _projects.Count,
            PageSize = param.PageSize,
            CurrentPage = param.CurrentPage,
            List = data
        };
    }

    public void Add(ProjectDto projectDto)
    {
        var lastId = _projects.Last().Id;
        projectDto.Id = ++lastId;
        _projects.Add(projectDto);
    }

    public void AddRange(IEnumerable<ProjectDto> projectDtos)
    {
        var lastId = _projects.Last().Id;
        foreach (var projectDto in projectDtos)
        {
            projectDto.Id = ++lastId;
        }
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

    public bool Delete(int id)
    {
        var project = _projects.FirstOrDefault(p => p.Id == id);
        if(project == null)
            return false;
        project.isDeleted = true;
        return true;
    }

    public bool Restore(int id)
    {
        var project = _projects.FirstOrDefault(p => p.Id == id);
        if(project == null)
            return false;
        project.isDeleted = false;
        return true;
    }

    private static bool ApplyFilter(ProjectDto projectDto, FilterColumn filterColumn)
    {
        if (filterColumn.Predicate.Split(':')[0].ToLower().Contains("@contains"))
        {
            var colValue = GetPropertyValue(projectDto, filterColumn.Column);
            if (colValue != null)
            {
                if (colValue is string)
                    return colValue.ToString()!.ToLower().Contains(filterColumn.Predicate.Split(':')[1].ToLower());
                if(colValue is int && int.TryParse(colValue!.ToString(), out int result))
                    return result.ToString().ToLower().Contains(filterColumn.Predicate.Split(':')[1].ToLower());
            }
        }
        if (filterColumn.Predicate.Split(':')[0].ToLower().Contains("@equals"))
        {
            var colValue = GetPropertyValue(projectDto, filterColumn.Column);
            if (colValue != null)
            {
                if (colValue is string)
                    return colValue.ToString()!.ToLower().Equals(filterColumn.Predicate.Split(':')[1].ToLower());
                if(colValue is int && int.TryParse(colValue!.ToString(), out var r1) && 
                   int.TryParse(filterColumn.Predicate.Split(':')[1], out int f1))
                    return r1 == f1;
                if (colValue is bool && bool.TryParse(colValue!.ToString(), out var r2) &&
                    bool.TryParse(filterColumn.Predicate.Split(':')[1], out var f2))
                    return r2 == f2;
            }
        }
        return false;
    }
    
    private static object? GetPropertyValue(object obj, string propertyName)
    {
        propertyName  = propertyName[0].ToString().ToUpper() + propertyName[1..];
        ArgumentNullException.ThrowIfNull(obj);
        if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));

        var propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (propertyInfo == null) throw new ArgumentException($"Property '{propertyName}' not found on object of type '{obj.GetType().Name}'.");

        return propertyInfo.GetValue(obj);
    }
}