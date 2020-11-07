using CoreWebAAPI.Dto;
using CoreWebAAPI.IServices;
using CoreWebAAPI.Mapper;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<int> AddProject(ProjectDto projecttype)
        {
            var projectType= ProjectMapper.AddProjectMapper(projecttype);
            return await _projectRepository.AddProject(projectType);
        }

        public Task<int> DeleteProject(ProjectDto projecttype)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            var projectType = await _projectRepository.GetAllProjects();
            return ProjectMapper.GetProjectMapper(projectType);
        }

        public Task<int> Updateroject(ProjectDto projecttype)
        {
            throw new NotImplementedException();
        }
    }
}
