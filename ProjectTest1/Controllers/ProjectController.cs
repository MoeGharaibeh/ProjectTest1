using Microsoft.AspNetCore.Mvc;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using ProjectTest1.Repository;
using ProjectTest1.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTest1.Controllers
{
    public class ProjectController : Controller
    {
        //call interface classes
        private IprojectRepository projectRepository;
        private IUserManagerRepository userManagerRepository;
        private IManagerRepository managerRepository;
        private IUserTeamLeaderRepository userTeamLeaderRepository;
        private IUserDeveloperRepository userDeveloperRepository;
        private IDeveloperRepository developerRepository;

        public ProjectController(
            IprojectRepository projectRepository,
            IUserManagerRepository userManagerRepository,
            IUserTeamLeaderRepository userTeamLeaderRepository,
            IUserDeveloperRepository userDeveloperRepository,
            IDeveloperRepository developerRepository,
             IManagerRepository managerRepository
            )
        {
            this.projectRepository = projectRepository;
            this.userManagerRepository = userManagerRepository;
            this.userTeamLeaderRepository = userTeamLeaderRepository;
            this.userDeveloperRepository = userDeveloperRepository;
            this.developerRepository = developerRepository;
            this.managerRepository = managerRepository;
        }




        //see all the prjects we have in the DataBase
        //public IActionResult AllProjects()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    ViewBag.AllProjects = projectRepository.GetAllProjects(userId);
        //    return View();
        //}

        //Create View
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.TeamLeaders = userTeamLeaderRepository.GetAllTeamLeaders();
            ViewBag.Developers = userDeveloperRepository.GetAllDevelopers();

            return View();
        }
        //Create POST
        [HttpPost]
        public IActionResult Create(CreateProjectDto createProjectDto)
        {
            managerRepository.AddProject(createProjectDto);
            return Redirect("ShowProjets");
        }

        [HttpGet]
        //Edit View
        public IActionResult Edit(int id)
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Developers = userDeveloperRepository.GetAllDevelopers();
            ViewBag.TeamLeaders = userTeamLeaderRepository.GetAllTeamLeaders();
            var project = projectRepository.GetProjectById(id);
            return View();
        }
        //Edit POST
        [HttpPost]
        public IActionResult Edit(EditProjectDto editProjectDto)
        {
            projectRepository.EditProject(editProjectDto);
            return Redirect("AllProjects");
        }
        //Rmove the Chosen Project from the data base
        //View
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var project = projectRepository.GetProjectById(id);
            return View(project);
        }
        //Remove POST*
        [HttpPost]
        public IActionResult Remove(Project project)
        {
            projectRepository.RemoveProject(project);
            return Redirect("AllProjects");
        }
        //Detials to the Chosen Project
        public IActionResult Detials(int id)
        {
            var project = projectRepository.DetialsProject(id);
            return View(project);
        }
    }
}
