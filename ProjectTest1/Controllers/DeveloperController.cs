using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using ProjectTest1.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ProjectTest1.Controllers
{
    public class DeveloperController : Controller
    {
        //call the Interface Classes
        private IDeveloperRepository developerRepository;
        private IprojectRepository projectRepository;
        public DeveloperController(IDeveloperRepository developerRepository, IprojectRepository projectRepository)
        {
            this.developerRepository = developerRepository;
            this.projectRepository = projectRepository;
        }
        //Get all the Developers in DataBase

        [Authorize(Roles ="Developer")]
        public IActionResult ShowWorks(int id)
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.works = developerRepository.GetWork(userId, id);

            return View();
        }
        [Authorize(Roles = "Developer")]
        [HttpGet]
        public IActionResult WorkPage(int id)
        {
            ViewBag.works = developerRepository.GetWorkById(id);
            return View();
        }
        [HttpPost]
        public IActionResult WorkPage(RejectionDto rejectionDto)
        {
            developerRepository.RejectedStatus(rejectionDto);
            return RedirectToAction("ShowWorks");
        }

        [Authorize(Roles = "Developer")]
        public IActionResult ShowProjects()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.projects = developerRepository.GetDeveloperProjects(userId);
            return View();
        }
        [Authorize(Roles = "Developer")]
        public IActionResult ShowSprints(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.sprint = developerRepository.GetSprint(id);

            return View();
        }
        [Authorize(Roles = "Developer")]
        public IActionResult ShowTaskes(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.taskes = developerRepository.GetTaskesBySprintId(id);
            return View();
        }
        //*******************************************************************************************
 
        [HttpGet]
        [Authorize(Roles = "Developer")]
        public IActionResult CreateWork(int id)
        {
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.taskId = id;

            return View();
        }
        [HttpPost]
        public IActionResult CreateWork(CreateWorkDto createWork)
        {
            developerRepository.AddWorkWithSingleFile(createWork);

            return Redirect("ShowProjects");
        }

        [Authorize(Roles = "Developer")]
        [HttpGet]
        public IActionResult EditWork(int id)
        {
           
            ViewBag.tasks = developerRepository.GetWorkById(id);

            return View();
        }
        [HttpPost]
        public IActionResult EditWork(EditWorkDto editWorkDto)
        {
      
            developerRepository.EditWork(editWorkDto);
            return Redirect("ShowWorks");
        }
        [Authorize(Roles = "Developer")]
        [HttpGet]
        public IActionResult RemoveWork(int id)
        {
            developerRepository.GetWorkById(id);//make a view
            return View();
        }
        [HttpPost]
        public IActionResult RemoveWork(Work RemoveWork)
        {
            developerRepository.RemoveWork(RemoveWork);
            return Redirect("ShowWorks");
        }
        //*******************************************************************************************
        public void ToggleAllStatus(string id)
        {

            developerRepository.checkStatus(id);

        }

        public FileStreamResult GetFile(int id)
        {
            var developer = developerRepository.GetDeveloper(id);
            Stream stream = new MemoryStream(developer.FileBytes);//from bytes to stream
            return new FileStreamResult(stream, developer.FileExtension);

        }
    }
}
