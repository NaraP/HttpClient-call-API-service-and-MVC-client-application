using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoreWebAAPI.Dto;
using CoreWebAAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWebAAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
            // = ReadBuildNumber();
            string buildVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }

        [HttpGet("GetProjectsData", Name = nameof(GetProjectsData))]
        public async Task<List<ProjectDto>> GetProjectsData()
        {
            return await _projectService.GetAllProjects().ConfigureAwait(false);
        }

        private string ReadBuildNumber()
        {
            var build = Assembly.GetExecutingAssembly();

            return Assembly.GetEntryAssembly()
                .GetCustomAttribute<BuildNumberAttribute>()
                .BuildNumber.Trim('"');

        }

        [HttpPost("CreateProject", Name = nameof(CreateProject))]
        public async Task<ActionResult> CreateProject([FromBody] ProjectDto project)
        {
            //var projectData = JsonConvert.DeserializeObject<ProjectDto>(project);

            int res = await _projectService.AddProject(project).ConfigureAwait(false);

            return StatusCode(200, res);
        }
    }
}
