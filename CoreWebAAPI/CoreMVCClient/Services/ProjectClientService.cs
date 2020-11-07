using CoreMVCClient.HttpClients;
using CoreMVCClient.IServices;
using CoreMVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCClient.Services
{
    public class ProjectClientService : IProjectClientService
    {
        private GenericRestfulCrudHttpClient<ProjectDto, string> projectClient = null;

        public ProjectClientService()
        {
            projectClient = new GenericRestfulCrudHttpClient<ProjectDto, string>("https://localhost:44348", "");
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjects()
        {
            var projects = await projectClient.GetManyAsync();
            return projects;
        }

        public async Task<int> AddProject(ProjectDto projecttype)
        {
            int result = 0;

            var addProject= await projectClient.PostAsync(projecttype).ConfigureAwait(false);

            if(addProject!=null)
            {
                result = 1;
            }
            return result;
        }

        public Task<int> DeleteProject(ProjectDto projecttype)
        {
            throw new NotImplementedException();
        }

      

        public Task<int> Updateroject(ProjectDto projecttype)
        {
            throw new NotImplementedException();
        }
    }
}
