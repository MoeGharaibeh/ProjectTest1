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
    public class ManagerRepository : IManagerRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;

        public ManagerRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public List<SprintTask> GetSprintTasksBySprintId(int Id)
        {
            return db.SprintTasks.Include(x => x.Developer).Where(x => x.SprintId == Id).ToList();

        }
        public List<Project> GetProjects(string id)
        {
           var t = db.Projects
            .Include(x => x.ProjectManager)
             .Include(x => x.ProjectDevelopers)
            .ThenInclude(x => x.Developer)
                .Where(x => x.ProjectManagerId == id).ToList();

            return t;

        }

        public void AddProject(CreateProjectDto createProjectDto)
        {
            var project = new Project
            {
                Title = createProjectDto.Title,
                Description = createProjectDto.Description,
                TeamleaderId = createProjectDto.TeamLeaderId,
                ProjectManagerId = createProjectDto.ProjectManagerId,
                status = createProjectDto.status

            };
            db.Projects.Add(project);
            db.SaveChanges();
            foreach (var item in createProjectDto.DeveloperIds)
            {
                db.ProjectDevelopers.Add(new ProjectDeveloper() { ProjectId = project.Id, DeveloperId = item });
                db.SaveChanges();
            }
        }

        public void EditProject(EditProjectDto editProject)
        {

            var project = db.Projects.Where(x => x.Id == editProject.Id).SingleOrDefault();
            project.Title = editProject.Title;
            project.Description = editProject.Description;
            project.TeamleaderId = editProject.TeamLeaderId;

            db.SaveChanges();

            //***********Developer***********
            var dev = db.ProjectDevelopers.Where(x => x.ProjectId == editProject.Id).ToList();

            db.SaveChanges();
            foreach (var item in dev)
            {
                db.ProjectDevelopers.Remove(item);
            }
            db.SaveChanges();
            foreach (var item in editProject.DeveloperIds)
            {
                db.ProjectDevelopers.Add(new ProjectDeveloper { ProjectId = editProject.Id, DeveloperId = item });
            }
            db.SaveChanges();

        }
        public void RemoveProject(Project removeProject)
        {
            var project = db.Projects.Where(x => x.Id == removeProject.Id).SingleOrDefault();
            db.Remove(project);
            db.SaveChanges();
            var developers = db.ProjectDevelopers.Where(x => x.ProjectId == removeProject.Id).ToList();
            foreach (var item in developers)
            {
                db.ProjectDevelopers.Remove(item);

            }
            db.SaveChanges();
        }

        public List<Sprint> GetSprints(int id)
        {
            return db.Sprints.Include(x => x.Project).Where(x => x.ProjectId == id).ToList();
        }

        public void ToggleStatus(int id)
        {
            var project = db.Projects.SingleOrDefault(x => x.Id == id);
            var CurentStatus = db.Projects.Where(x => x.Id == id).Select(x => x.status).SingleOrDefault();
            if (CurentStatus == Status.Pendding)
            {
                project.status = Status.Completed;
            }
            else
            {
                project.status = Status.Pendding;
            }
            db.SaveChanges();
        }

        //public List<Work> GetWorkByDeveloperById(string id)
        //{
        //   return db.Works.Include(x=>x.Files).
        //      Where(x => x.DeveloperId == id).ToList();
        //}

        public List<Work> GetWorkByManagerId(int id)
        {
            return db.Works.Include(x => x.Files).
               Where(x => x.SprintTaskId == id).ToList();
        }
        public List<Work> GetWorksByDeveloperId(int taskId , string id)
        {
            return db.Works.Include(x => x.Files)
                 .Where(x => x.SprintTaskId == taskId)
                 .Where(x => x.DeveloperId == id)
                 .ToList();
        }


        public Work GetWorkById(int id)
        {
            return db.Works.Where(x => x.Id == id).SingleOrDefault();
        }

    }
}
