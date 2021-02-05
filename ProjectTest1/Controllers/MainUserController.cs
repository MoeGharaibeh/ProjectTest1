using Microsoft.AspNetCore.Authorization;
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
    public class MainUserController : Controller
    {
        private IUserManagerRepository userManagerRepository;
        private IUserTeamLeaderRepository userTeamLeaderRepository;
        private IUserDeveloperRepository userDeveloperRepository;

        public MainUserController(IUserManagerRepository userManagerRepository, IUserTeamLeaderRepository userTeamLeaderRepository, IUserDeveloperRepository userDeveloperRepository)
        {
            this.userManagerRepository = userManagerRepository;
            this.userTeamLeaderRepository = userTeamLeaderRepository;
            this.userDeveloperRepository = userDeveloperRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Managers = userManagerRepository.GetAllManagers();
            ViewBag.TeamLeaders = userTeamLeaderRepository.GetAllTeamLeaders();
            ViewBag.Developers = userDeveloperRepository.GetAllDevelopers();
            return View();
        }
       

        // Manager
        [HttpGet]
        public IActionResult CreateManager()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateManager(CreateDto createManagerDto)
        {
            if (ModelState.IsValid)
            {
                await userManagerRepository.CreateManager(createManagerDto);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        //EDIT VIEW
        [HttpGet]
        public IActionResult EditManager(string id)
        {
            ViewBag.manager = userManagerRepository.GetManagerId(id);
            return View();
        }
        //Edit POST
        [HttpPost]
        public IActionResult EditManager(EditDto editManagerDto)
        {
            userManagerRepository.EditManager(editManagerDto);
            return RedirectToAction("Index","MainUser",editManagerDto.Id);
        }

        //Remove GET
        [HttpGet]
        public IActionResult RemoveManager(string id)
        {
            var manager =  userManagerRepository.GetManagerId(id);
            return View(manager);
        }

        //Remove POST
        [HttpPost]
        public IActionResult RemoveManager(ProjectManager manager)
        {
            userManagerRepository.RemoveProjectManager(manager);
            return Redirect("Index");
        }

        public IActionResult ManagerDetials(string id)
        {
            var managerDetials =  userManagerRepository.ManagerDetials(id);
            return View(managerDetials);
        }

        //*************************************************************************************************************************************

        /// TEAMLEADER
        [HttpGet]
        public IActionResult CreateTeamLeader()
        {
          
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateTeamLeader(CreateDto createDto)
        {
            {
                if (ModelState.IsValid)
                {
                    await userTeamLeaderRepository.CreateTeamLeader(createDto);
                    return Redirect("Index");
                }
                else
                {
                    return View();
                }

            }
        }
        //Edit GET
        [HttpGet]
        public IActionResult EditTeamLeader(string id)
        {
            ViewBag.teamLeader = userTeamLeaderRepository.GetTeamLeaderId(id);
            return View();
        }
        //EDIT POST
        [HttpPost]
        public IActionResult EditTeamLeader(EditDto editTeamLeaderDto)
        {
            userTeamLeaderRepository.EditTeamLeader(editTeamLeaderDto);
            return RedirectToAction("Index", "MainUser", editTeamLeaderDto.Id);
        }
        //Remove GET
        [HttpGet]
        public IActionResult RemoveLeader(string id)
        {
           
            var teamLeader = userTeamLeaderRepository.GetTeamLeaderId(id);
            return View(teamLeader);

        }
        //Remove POST
        [HttpPost]
        public IActionResult RemoveLeader(TeamLeader teamLeader)
        {
            userTeamLeaderRepository.RemoveTeamLeader(teamLeader);
            return Redirect("Index");
        }
        public IActionResult DetialsLeader(string id)
        {
            var teamLeader = userTeamLeaderRepository.DetialsTeamLeader(id);
            return View(teamLeader);
        }

        // ******************************************************************************************************************
            

        /// DEVELOPER

        [HttpGet]
        public IActionResult CreateDeveloper()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateDeveloper(CreateDto createDto)
        {
            if (ModelState.IsValid)
            {
                await userDeveloperRepository.CreateDeveloper(createDto);
                return Redirect("Index");
            }
            else
            {
                return View();
            }
        }


        //EDIT VIEW GET
        [HttpGet]
        public IActionResult EditDeveloper(string id)
        {
            ViewBag.developer = userDeveloperRepository.GetDeveloperId(id);
            return View();
        }
        public IActionResult EditDeveloper(EditDto editDeveloperDto)
        {
            userDeveloperRepository.EditDeveloper(editDeveloperDto);
            return RedirectToAction("Index", "MainUser", editDeveloperDto.Id);
        }

        [HttpGet]
        public IActionResult RemoveDeveloper(string id)
        {
            var developer = userDeveloperRepository.GetDeveloperId(id);
            return View(developer);

        }
        [HttpPost]
        public IActionResult RemoveDeveloper(Developer developer)
        { 
            userDeveloperRepository.RemoveDeveloper(developer);
            return Redirect("Index");
        }

        public IActionResult DetialsDeveloper(string id)
        {
            var developer = userDeveloperRepository.DetialsDeveloper(id);
            return View(developer);
        }
    }
}
