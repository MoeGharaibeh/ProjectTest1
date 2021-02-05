using Microsoft.AspNetCore.Mvc;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using ProjectTest1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectTest1.Controllers
{
    public class SprintController : Controller
    {
        private ISprintRepository sprintRepository;
        private IDeveloperRepository developerRepository;
        private ITeamLeaderRepository teamLeaderRepository;

        public SprintController(ISprintRepository sprintRepository , ITeamLeaderRepository teamLeaderRepository, IDeveloperRepository developerRepository)
        {
            this.sprintRepository = sprintRepository;
            this.developerRepository = developerRepository;
            this.teamLeaderRepository = teamLeaderRepository;
        }
        public IActionResult AllSprints(int projectId)
        {
            ViewBag.AllSprints = sprintRepository.GetAllSprints(projectId);


            ViewBag.ProjectIds = projectId;

            return View();
         
        }
        [HttpGet]
        public IActionResult Create()
        {
      
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.projects = sprintRepository.GetSprintByTeamLeaderId(userId);

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSprintDto createSprint)
        {
            sprintRepository.CreateSprint(createSprint);
            return Redirect("AllSprints");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sprint = sprintRepository.GetSprintById(id);
            return View(sprint);
        }
        [HttpPost]
        public IActionResult Edit(EditSprintDto editSprintDto)
        {
            sprintRepository.EditSprint(editSprintDto);
            return Redirect("AllSprints");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Remove(Sprint removeSprint)
        {
            return View();
        }
        public IActionResult Detials(int id)
        {
            return View();
        }
    }
}
