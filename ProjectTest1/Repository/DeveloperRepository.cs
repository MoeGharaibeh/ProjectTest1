using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTest1.Data;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public DeveloperRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public void RejectedStatus(RejectionDto rejectionDto)
        {
            var work = db.Works.Where(x => x.Id == rejectionDto.Id).SingleOrDefault();
            work.workStatus = WorkStatus.Rejected;
            work.RecjectionNote = rejectionDto.RecjectionNote;
            db.SaveChanges();
        }
        public void AddWorkAPI(AddWorkAPIDto createWork)
        {
            var work = new Work() {

                Title = createWork.Title,
                Description = createWork.Description,
                workStatus = WorkStatus.Pendding,
                DeveloperId = createWork.DeveloperId,
                SprintTaskId = createWork.SprintTaskId,
            };
            db.Works.Add(work);
                db.SaveChanges();
        }

        public void EditWorkAPI(EditWorkDto editWork)
        {
            var work = db.Works.Where(x => x.Id == editWork.Id).SingleOrDefault();
            work.Title = editWork.Title;
            work.Description = editWork.Description;
            work.DeveloperId = "0c3d9737-6590-45d1-8cde-5dcd65369548";
            work.SprintTaskId = 10;

            db.SaveChanges();
        }
        public List<ProjectDeveloper> GetDeveloperProjects(string id)
        {
            //return db.Developers.Include(x => x.ProjectDevelopers).ThenInclude(x=>x.Project).Where(x=>x.Id == id).ToList();
            var projects = db.ProjectDevelopers.Include(x => x.Developer)
      
            .Include(x => x.Project).ThenInclude(x => x.ProjectManager)
          
            .Where(x => x.DeveloperId == id).ToList();
            return projects;
        }
   

        public List<Sprint> GetSprint(int id)
        {
            return db.Sprints.Include(x => x.Project).Where(x => x.ProjectId == id).ToList();
        }

        public List<SprintTask> GetTaskesBySprintId(int id)
        {
            return db.SprintTasks.Include(x=>x.Developer)
                     .Where(x => x.SprintId == id).ToList();
        }
        public List<SprintTask> GetTaskesByDeveloperId(string id)
        {
            return db.SprintTasks.Where(x => x.DeveloperId == id).ToList();
        }

    

        public void AddWorkWithSingleFile(CreateWorkDto createWork)
        {
            var work = new Work
            {
                Title = createWork.Title,
                Description = createWork.Description,
                workStatus = WorkStatus.Pendding,
                DeveloperId = createWork.DeveloperId,
                SprintTaskId = createWork.SprintTaskId,
                

            };
            db.Works.Add(work);
            db.SaveChanges();

            Stream st = createWork.TheFile.OpenReadStream();
            // strem file inside it
            using (BinaryReader br = new BinaryReader(st))//binary reader stream inside it 
            {
                var byteFile = br.ReadBytes((int)st.Length);
                var file = new Models.File();
                file.FileName = createWork.TheFile.FileName;
                file.FileExtension = createWork.TheFile.ContentType;
                file.FileBytes = byteFile;
                file.WorkId = work.Id;

                db.Files.Add(file);
                db.SaveChanges();
            }
        
            db.SaveChanges();

        }

        public void EditWork(EditWorkDto editWork)
        {
            var work = db.Works.Where(x => x.Id == editWork.Id).SingleOrDefault();
            work.Title = editWork.Title;
            work.Description = editWork.Description;
          
            db.SaveChanges();
        }
        public void RemoveWork(Work RemoveWork)
        {
            db.Works.Remove(RemoveWork);
            db.SaveChanges();
     
        }

        public List<Work> GetWork(string UserId , int TaskId)
        {
           return db.Works.Include(x => x.Developer)
                .Where(x => x.DeveloperId == UserId)
                .Where(x=>x.SprintTaskId == TaskId)
                .ToList();
        }

        public Work GetWorkById(int id)
        {
            return db.Works.Where(x => x.Id == id).SingleOrDefault();
        }

        public List<SprintTask> ShowTaskes(string id)
        {
            return db.SprintTasks.Where(x => x.DeveloperId == id).ToList();
        }

        public void checkStatus(string Id)
        {
            var works = db.Works.Include(x => x.Developer)
                                .Where(x => x.DeveloperId == Id)
                                .ToList();

            var workStatusCheck = db.Works.Include(x => x.Developer)
                                          .Where(x => x.DeveloperId == Id)
                                          .Select(x => x.workStatus)
                                          .ToList();

            var statusList = new List<WorkStatus>();

            works.Count();

            foreach (var item in works)
            {
                if (item.workStatus == WorkStatus.Approved)
                {
                    statusList.Add(item.workStatus);
                }
                else
                {
                    break;
                }
            }

            if (statusList.Count() == workStatusCheck.Count())
            {
                this.ToggleAllStatus(Id);
            }
        }
        public void ToggleAllStatus(string Id)
        {
            var works = db.Works.Include(x => x.Developer).Where(x => x.DeveloperId == Id).ToList();
      
            foreach (var item in works)
            {
                item.workStatus = WorkStatus.Completed;
                db.SaveChanges();
            }
        }



        public Models.File GetDeveloper(int id)
        {
            return db.Files.Where(x =>x.WorkId == id).SingleOrDefault();
                               
        }
        public Models.File GetFileByDeveloper(int id)//wrong
        {
            return db.Files.Include(x=>x.Work).Where(x=>x.WorkId == id).SingleOrDefault();
        }
        public void AddWork(CreateWorkDto createWork)
        {
            throw new NotImplementedException();
        }

        public List<Work> GetWorksByDeveloperId(int taskId, string id)
        {
            throw new NotImplementedException();
        }

        public void ToggleAllStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}
