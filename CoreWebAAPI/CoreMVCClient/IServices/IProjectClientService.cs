using CoreMVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCClient.IServices
{
   public interface IProjectClientService
    {
        Task<int> AddProject(ProjectDto projecttype);
        Task<int> Updateroject(ProjectDto projecttype);
        Task<int> DeleteProject(ProjectDto projecttype);
        Task<IEnumerable<ProjectDto>> GetAllProjects();
    }
}
