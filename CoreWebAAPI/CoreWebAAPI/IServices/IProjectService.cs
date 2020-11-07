using CoreWebAAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAAPI.IServices
{
    public interface IProjectService
    {
        Task<int> AddProject(ProjectDto projecttype);
        Task<int> Updateroject(ProjectDto projecttype);
        Task<int> DeleteProject(ProjectDto projecttype);
        Task<List<ProjectDto>> GetAllProjects();
    }
}
