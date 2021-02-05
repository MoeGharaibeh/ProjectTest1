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
    public class WorkController : Controller
    {
        private IWorkRepository workRepository;
        public WorkController(IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
        }
        public IActionResult GetAllWorks()
        {
            ViewBag.AllWorks = workRepository.GetAllWorks();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateWorkDto createWorkDto)
        {
            workRepository.CreateWork(createWorkDto);
            return Redirect("GetAllWorks");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var work = workRepository.GetWorkById(id);
            return View(work);
        }
        [HttpPost]
        public IActionResult Edit(EditWorkDto editWorkDto)
        {
            workRepository.EditWork(editWorkDto);
            return Redirect("GetAllWorks");
        }
        [HttpGet]
        public IActionResult Remove(int id )
        {
            return View();
        }
        [HttpPost]
        public IActionResult Remove(Work work)
        {
            workRepository.RemoveWork(work);
            return Redirect("GetAllWorks");
        }

        public IActionResult Detials(int id)
        {
            workRepository.DetialsWork(id);
            return View();
        }
    }
}
