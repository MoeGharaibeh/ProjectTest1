using Microsoft.AspNetCore.Mvc;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using ProjectTest1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Controllers
{
    public class SprintTaskController : Controller
    {
        private ISprintTaskRepository sprintTaskRepository;
        public SprintTaskController(ISprintTaskRepository sprintTaskRepository)
        {
            this.sprintTaskRepository = sprintTaskRepository;
        }
        public IActionResult AllTaskes()
        {
            ViewBag.AllTaskes = sprintTaskRepository.GetAllTasks();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(CreateTaskDto createTaskDto)
        {
            sprintTaskRepository.CreateSprintTask(createTaskDto);
            return Redirect("AllTaskes");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = sprintTaskRepository.GetTaskById(id);
            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(EditTaskDto editTaskDto)
        {
            sprintTaskRepository.EditTask(editTaskDto);
            return Redirect("AllTaskes");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var task = sprintTaskRepository.GetTaskById(id);
            return View(task);
        }
        [HttpPost]
        public IActionResult Remove(SprintTask removeTask)
        {
            sprintTaskRepository.RemoveTask(removeTask);
            return Redirect("AllTaskes");
        }

        public IActionResult Detials(int id)
        {
            var task = sprintTaskRepository.GetTaskById(id);
            return View(task);
        }
    }
}
