using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTest1.Dto;
using ProjectTest1.Helpers;
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
    public class ProjectManagerController : Controller
    {
        private IUserManagerRepository userManagerRepository;
        private IUserTeamLeaderRepository userTeamLeaderRepository;
        private IUserDeveloperRepository userDeveloperRepository;
        private IManagerRepository managerRepository;
        MailHelper mail = new MailHelper();
    
        public ProjectManagerController(IUserManagerRepository userManagerRepository,
            IUserTeamLeaderRepository userTeamLeaderRepository,
            IUserDeveloperRepository userDeveloperRepository,
            IManagerRepository managerRepository)
        {
            this.userManagerRepository = userManagerRepository;
            this.userTeamLeaderRepository = userTeamLeaderRepository;
            this.userDeveloperRepository = userDeveloperRepository;
            this.managerRepository = managerRepository;
        }


     

        //All Projects
        public IActionResult ShowProjets()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.AllProjects = managerRepository.GetProjects(id);
   
       
            return View("ShowProjets");
        }
        //All Works
        public IActionResult ShowWorks(int taskId , string id)
        {
        
            ViewBag.works= managerRepository.GetWorksByDeveloperId(taskId , id);

            return View();
        }
        //All Sprints
        public IActionResult ShowSprint(int id)
        {
            ViewBag.projectId = managerRepository.GetSprints(id);
            return View();
        }
        public IActionResult ShowTasks(int id)
        {
            ViewBag.tasks = managerRepository.GetSprintTasksBySprintId(id);
            return View();
        }

        public IActionResult WorkPage(int id)
        {
            ViewBag.works= managerRepository.GetWorkById(id);
            return View();
        }


        //Create a new Project GET
        [HttpGet]
        public IActionResult CreateProject()
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.TeamLeaders = userTeamLeaderRepository.GetAllTeamLeaders();
            ViewBag.Developers = userDeveloperRepository.GetAllDevelopers();
            return View();
        }
        //Create a new Project POST
        [HttpPost]
        public IActionResult CreateProject(CreateProjectDto createDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
               
                managerRepository.AddProject(createDto);
                mail.SendMail("mohammad.yh.gh@gmail.com", "mohammad yahya ", User.Identity.Name);
                return RedirectToAction("ShowProjets", "ProjectManager");
            }
            else
            {
                ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                ViewBag.TeamLeaders = userTeamLeaderRepository.GetAllTeamLeaders();
                ViewBag.Developers = userDeveloperRepository.GetAllDevelopers();
                return View();
            }
        }

        //Edit a Project View
        [Authorize(Roles ="ProjectManager")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Developers = userDeveloperRepository.GetAllDevelopers();
            ViewBag.TeamLeaders = userTeamLeaderRepository.GetAllTeamLeaders();
            ViewBag.project = userManagerRepository.GetProjectById(id);
            return View();
        }
        //Edit a Project POST
        [Authorize(Roles = "ProjectManager")]
        [HttpPost]
        public IActionResult Edit(EditProjectDto editProjectDto )
        {
            var id = editProjectDto.Id;
            if (ModelState.IsValid)
            {
                managerRepository.EditProject(editProjectDto);
                return Redirect("ShowProjets");
            }
            else
            {

                ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                ViewBag.Developers = userDeveloperRepository.GetAllDevelopers();
                ViewBag.TeamLeaders = userTeamLeaderRepository.GetAllTeamLeaders();
                ViewBag.project = userManagerRepository.GetProjectById(id);
                return View();
            }
        
        }


        //Toggle Status
        public void ToggleStatus(int id)
        {
            managerRepository.ToggleStatus(id);

        }


        //View
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var project = userManagerRepository.GetProjectById(id);
            return View(project);
        }
        //Remove POST*
        [HttpPost]
        public IActionResult Remove(Project project)
        {
            managerRepository.RemoveProject(project);
            return Redirect("AllProjects");
        }
    }
}
