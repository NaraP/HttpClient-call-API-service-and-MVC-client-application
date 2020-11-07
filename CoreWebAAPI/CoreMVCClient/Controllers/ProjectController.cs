using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCClient.IServices;
using CoreMVCClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCClient.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectClientService _projectClientService;
        public ProjectController(IProjectClientService projectClientService)
        {
            _projectClientService = projectClientService;
        }
        // GET: ProjectController
        public async Task<ActionResult> Index()
        {
            var result = await _projectClientService.GetAllProjects();

            return View(result);
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            try
            {
                ProjectDto projectDto = new ProjectDto();
                projectDto.ProjectName = project.ProjectName;
                projectDto.ProjectId = Guid.NewGuid();
                projectDto.IsActive = true;

                var result = _projectClientService.AddProject(projectDto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
