using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTest1.Dto;
using ProjectTest1.Helpers;
using ProjectTest1.Models;
using ProjectTest1.Repository;
using ProjectTest1.Repository.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTest1.Controllers
{
    public class TeamLeaderController : Controller
    {
        private ITeamLeaderRepository teamLeaderRepository;
        private IprojectRepository projectRepository;
        private IUserDeveloperRepository userDeveloperRepository;
        MailHelper mail = new MailHelper();

        public TeamLeaderController(ITeamLeaderRepository teamLeaderRepository,
            IprojectRepository projectRepository,
            IUserDeveloperRepository userDeveloperRepository)
        {
            this.teamLeaderRepository = teamLeaderRepository;
            this.projectRepository = projectRepository;
            this.userDeveloperRepository = userDeveloperRepository;
        }



        //show Work
        [Authorize(Roles ="TeamLeader")]
        public IActionResult ShowWorks(int taskId, string id)
        {
            //getworksbydevid

            ViewBag.works = teamLeaderRepository.GetWorksByDeveloperId(taskId, id);
            return View();
        }
        //show tasks
        [Authorize(Roles = "TeamLeader")]
        public IActionResult ShowTasks(int id)
        {
            ViewBag.tasks = teamLeaderRepository.GetSprintTasksBySprintId(id);
            return View();
        }

        //Sprints
        [Authorize(Roles = "TeamLeader")]
        public IActionResult ShowSprints(int id)
        {
            ViewBag.sprints = teamLeaderRepository.GetSprint(id);
            return View();
        }

        //Projects
        [Authorize(Roles = "TeamLeader")]
        public IActionResult ShowProject()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.projects = teamLeaderRepository.GetProjects(userId);
            return View();
        }



        //***************************TASkES*******************************

        //create a new  Taskes
        [Authorize(Roles = "TeamLeader")]
        [HttpGet]
        public IActionResult CreateTask(int id)
        {
            var sprintId = teamLeaderRepository.GetSprintById(id);
            ViewBag.developers = teamLeaderRepository.GetDevelopers(sprintId.ProjectId);
            ViewBag.sprint = id;
            return View();
        }
        [Authorize(Roles = "TeamLeader")]
        [HttpPost]
        public IActionResult CreateTask(CreateTaskDto createTaskDto)
        {
            var title = createTaskDto.Title;
            teamLeaderRepository.CreateSprintTask(createTaskDto);
            mail.SendMailForATask("mohammad.yh.gh@gmail.com", "mohammad yahya " , User.Identity.Name , title);
            return Redirect("ShowProject");
        }
        [Authorize(Roles = "TeamLeader")]
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var tasks = teamLeaderRepository.GetTasksBySprintId(id);

            ViewBag.developers = teamLeaderRepository.GetDevelopers(tasks.Sprint.Project.Id);
            ViewBag.Tasks = teamLeaderRepository.GetSprintTaskById(id);
            return View();


        }
        [Authorize(Roles = "TeamLeader")]
        [HttpPost]
        public IActionResult EditTask(EditTaskDto editTaskDto)
        {
            teamLeaderRepository.EditTask(editTaskDto);
            return Redirect("ShowProject"); //redicret
        }


        //**************************************************


        //********************Sprints*************************
        [Authorize(Roles = "TeamLeader")]
        [HttpGet]
        public IActionResult CreateSprint(int id)
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ViewBag.projectId = id;
            return View();
        }
        [Authorize(Roles = "TeamLeader")]
        [HttpPost]
        public IActionResult CreateSprint(CreateSprintDto createSprint)
        {
            teamLeaderRepository.CreateSprint(createSprint);
            return Redirect("ShowProject");
        }
        [Authorize(Roles = "TeamLeader")]
        [HttpGet]
        public IActionResult EditSprint(int id)
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.sprint = teamLeaderRepository.GetSprintById(id);

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "TeamLeader")]
        public IActionResult EditSprint(EditSprintDto editSprint)
        {
            teamLeaderRepository.EditSprint(editSprint);
            return Redirect("ShowProject");
        }
      


        public void SprintStatus(int id)
        {
            teamLeaderRepository.SprintStatus(id);

        }
   
        public void TaskStatus(int id)
        {
            teamLeaderRepository.TaskStatus(id);
        }
        public IActionResult ToggleWorkStatus(int id)
        {
            teamLeaderRepository.ToggleWorkStatus(id);
            return View();
        }
        public IActionResult RejectionNote()
        {
            return View();
        }
        public void SubmitAllStatus(int ProjectId)
        {
            teamLeaderRepository.checkStatus(ProjectId);
        }
        [Authorize(Roles = "TeamLeader")]
        [HttpGet]
        public IActionResult WorkPage(int id)
        {
            ViewBag.works = teamLeaderRepository.GetWorkById(id);
            return View();
        }
        [Authorize(Roles = "TeamLeader")]
        [HttpPost]
        public IActionResult WorkPage(RejectionDto rejectionDto)
        {
            teamLeaderRepository.RejectedStatus(rejectionDto);
            return RedirectToAction("ShowProject");
        }

       
    }
}
