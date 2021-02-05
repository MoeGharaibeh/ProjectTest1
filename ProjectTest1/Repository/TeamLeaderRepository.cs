using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTest1.Data;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public class TeamLeaderRepository : ITeamLeaderRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public TeamLeaderRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        //Get All Projects for the logged in user
        public List<Project> GetProjects(string id)
        {

            var t = db.Projects
            .Include(x => x.ProjectManager)
            .Include(x => x.ProjectDevelopers)
            .ThenInclude(x => x.Developer)
            .Where(x => x.TeamleaderId == id).ToList();

            return t; 
        }
        //Get sprints By project Id
        public List<Sprint> GetSprint(int id)
        {
            return db.Sprints.Include(x => x.Project).Where(x => x.ProjectId == id).ToList();
        }
   
        //Add a new Sprint
        public void CreateSprint(CreateSprintDto createSprint)
        {
            var sprint = new Sprint
            {
                Title = createSprint.Title,
                Description = createSprint.Description,
                status = Status.Pendding,
                StartDate = DateTime.Now,
                EndDate = createSprint.EndDate,
                ProjectId = createSprint.ProjectId,
                TeamleaderId = createSprint.TeamleaderId
            };

       
            db.Sprints.Add(sprint);
            db.SaveChanges();
        }


        //Modify The sprint 
        public void EditSprint(EditSprintDto editSprint)
        {
            var sprint = db.Sprints.Where(x => x.Id == editSprint.Id).SingleOrDefault();
            sprint.Title = editSprint.Title;
            sprint.Description = editSprint.Description;
            sprint.StartDate = editSprint.StartDate;
            sprint.EndDate = editSprint.EndDate;
    
            db.SaveChanges();
        }

      
        //this function has been created to return the projectId
        public Sprint GetSprintById(int id)
        {
            return db.Sprints.Where(x => x.Id == id).SingleOrDefault();
        }
        public List<Project> GetSprintByTeamLeaderId(string id)
        {
            return db.Projects.Include(x => x.Sprints).Where(x => x.TeamleaderId == id).ToList();
        }

        //*******************************TASK******************************************

     
        //get the task by the sprint id (sprint(task))
        public List<SprintTask> GetSprintTasksBySprintId(int Id)
        {
            return db.SprintTasks.Include(x => x.Developer).Where(x => x.SprintId == Id).ToList();

        }

        //to get  the actual task by the sprint id and then use it in the GetDevelopers method to get the sprint.projectID
        public SprintTask GetTasksBySprintId(int id)
        {
          return db.SprintTasks.Include(x => x.Sprint).ThenInclude(x => x.Project).Where(x => x.Id == id).SingleOrDefault();
        }
        public SprintTask GetSprintTaskById(int id)
        {
            return db.SprintTasks.Where(x => x.Id == id).SingleOrDefault();
        }

        //Add A new Task
        public void CreateSprintTask(CreateTaskDto createTask)
        {
            var task = new SprintTask
            {
                Title = createTask.Title,
                Description = createTask.Description,
                status = Status.Pendding,
                DeveloperId = createTask.DeveloperId,
                SprintId = createTask.SprintId
            };
            db.SprintTasks.Add(task);
            db.SaveChanges();
        }












        //modify the Task 
        public void EditTask(EditTaskDto editSprint)
        {
            var task = db.SprintTasks.Where(x => x.Id == editSprint.Id).SingleOrDefault();
            task.Title = editSprint.Title;
            task.Description = editSprint.Description;
            task.DeveloperId = editSprint.DeveloperId;

            db.SaveChanges();
        }

        
        //Get the works that are for the chosen Developer
        public List<Work> GetWorksByDeveloperId(int taskId,string id)
        {
            return db.Works.Include(x=>x.Files)
                .Where(x=>x.SprintTaskId == taskId)
                .Where(x => x.DeveloperId == id)         
                .ToList();
        }
  
        //Task Status Toggle
        public void TaskStatus(int id)
        {

            var task = db.SprintTasks.SingleOrDefault(x => x.Id == id);
            var CurentStatus = db.SprintTasks.Where(x => x.Id == id).Select(x => x.status).SingleOrDefault();
            if (CurentStatus == Status.Pendding)
            {
                task.status = Status.Completed;
            }
            else
            {
                task.status = Status.Pendding;
            }
            db.SaveChanges();
        }


        //Sprint Status Toggle
        public void SprintStatus(int id)
        {

            var sprint = db.Sprints.SingleOrDefault(x => x.Id == id);
            var CurentStatus = db.Sprints.Where(x => x.Id == id).Select(x => x.status).SingleOrDefault();
            if (CurentStatus == Status.Pendding)
            {
                sprint.status = Status.Completed;
            }
            else
            {
                sprint.status = Status.Pendding;
            }
            db.SaveChanges();
        }
        //Work Status Toggle 
        public void ToggleWorkStatus(int id)
        {
            var work = db.Works.SingleOrDefault(x => x.Id == id);
            var CurentStatus = db.Works.Where(x => x.Id == id).Select(x => x.workStatus).SingleOrDefault();
            if (CurentStatus == WorkStatus.Pendding)
            {
                work.workStatus = WorkStatus.Approved; //
            }
            else
            {
                work.workStatus = WorkStatus.Pendding;
            }
            db.SaveChanges();
        }








        //For Rejection Note that come form the teamleader to the developer

        public void RejectedStatus(RejectionDto rejectionDto)
        {
            var work = db.Works.Where(x => x.Id == rejectionDto.Id).SingleOrDefault();
            work.workStatus = WorkStatus.Rejected;
            work.RecjectionNote = rejectionDto.RecjectionNote;
            db.SaveChanges();
        }

        //used in the work page 
        public Work GetWorkById(int id)
        {
            return db.Works.Where(x => x.Id == id).SingleOrDefault();
        }


        //Get the developers by the project ID
        public List<ProjectDeveloper> GetDevelopers(int id)
        {
            return db.ProjectDevelopers.Include(x => x.Project)
                 .Include(x => x.Developer).Where(x => x.ProjectId == id).ToList();

        }













        //Make check on all status 
        public void checkStatus(int Id)
        {
            var sprints = db.Sprints.Include(x => x.Project)
                                .Where(x => x.ProjectId == Id)
                                .ToList();
            var projectStatusCheck = db.Sprints.Include(x => x.Project)
                                               .Where(x => x.ProjectId == Id)
                                               .Select(x => x.status)
                                               .ToList();

            var statusList = new List<Status>();
            foreach (var item in sprints)
            {
                if (item.status == Status.Completed)
                {
                    statusList.Add(item.status);
                }
                else
                {
                    break;
                }
            }
            if (statusList.Count() == projectStatusCheck.Count())
            {
                this.CompleteProject(Id);
            }
        }

        //used in the method checkStatus
        private void CompleteProject(int Id)
        {
            var project = db.Projects.Where(x => x.Id == Id).SingleOrDefault();
            project.status = Status.Completed;
            db.SaveChanges();
        }


    }
}
