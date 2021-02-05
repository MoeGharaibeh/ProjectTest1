using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]/[Action]")]
    [ApiController]


    public class WorkAPIController : ControllerBase
    {
        private IDeveloperRepository developerRepository;

        public WorkAPIController(IDeveloperRepository developerRepository)
        {
            this.developerRepository = developerRepository;
        }

     //api/WorkAPI/Create?taskId=10&id=0c3d9737-6590-45d1-8cde-5dcd65369548
        [HttpGet]
        public IActionResult GetWork(int id)
        {
            //var id = "0c3d9737-6590-45d1-8cde-5dcd65369548";
            var UID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var AllWorks = developerRepository.GetWorkById(id);
            
       
            return new JsonResult(AllWorks);
        }
        public IActionResult GetWorks(int id)
        {
            var UID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return new JsonResult(developerRepository.GetWork(UID, id).ToList());
        }
        [HttpGet]
        public IActionResult WorkPage(int Id)
        {
            var work = developerRepository.GetWorkById(Id);
            return new JsonResult(work);
        }
        public void Create([FromBody]AddWorkAPIDto create)
        {
            developerRepository.AddWorkAPI(create);
        }
        [HttpPut]
        public void Edit([FromBody] EditWorkDto editWork)
        {
            developerRepository.EditWorkAPI(editWork);
        }
        
        [HttpDelete]
        public void Delete(int id ,[FromBody]Work work)
        {
            developerRepository.RemoveWork(work);
        }
    }
}
