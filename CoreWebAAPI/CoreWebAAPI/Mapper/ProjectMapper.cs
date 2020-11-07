using CoreWebAAPI.Dto;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAAPI.Mapper
{
    public static class ProjectMapper
    {
        public static Projecttype  AddProjectMapper(ProjectDto projectDto)
        {
            Projecttype projecttype = new Projecttype();
            projecttype.ProjectId = Guid.NewGuid();
            projecttype.ProjectName = projectDto.ProjectName;
            projecttype.IsActive = projectDto.IsActive;

            return projecttype;
        }

        public static List<ProjectDto> GetProjectMapper(List<Projecttype> projectType)
        {
            ProjectDto projectDto = null;

            List<ProjectDto> projectDtos = new List<ProjectDto>();

            foreach(var proj in projectType)
            {
                projectDto = new ProjectDto();
                projectDto.ProjectId = proj.ProjectId;
                projectDto.ProjectName = proj.ProjectName;
                projectDto.IsActive = proj.IsActive;

                projectDtos.Add(projectDto);
            }
            return projectDtos;
        }
    }
}
