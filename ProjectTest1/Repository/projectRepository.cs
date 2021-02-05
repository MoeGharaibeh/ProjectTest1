using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTest1.Data;
using ProjectTest1.Dto;
using ProjectTest1.Helpers;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public class projectRepository : IprojectRepository
    {
        private ApplicationDbContext db;
        MailHelper mail = new MailHelper();
        public projectRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Project> GetAllProjects(string id )
        {
            return db.Projects.Include(x => x.TeamLeader)
            .Include(x => x.ProjectManager)
            .Include(x => x.ProjectDevelopers)
            .ThenInclude(x => x.Developer)
            .Where(x => x.ProjectManagerId == id).ToList();
        }

        public void CreateProject(CreateProjectDto createProjectDto)
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
            var project = db.Projects.Where(x=>x.Id == editProject.Id).SingleOrDefault();
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
                db.ProjectDevelopers.Add(new ProjectDeveloper {ProjectId = editProject.Id , DeveloperId = item});
            }
            db.SaveChanges();

          
        }
        public void RemoveProject(Project RemoveProject)
        {
            var project = db.Projects.Where(x=>x.Id == RemoveProject.Id).SingleOrDefault();
            db.Projects.Remove(project);
            db.SaveChanges();
        }

        public Project DetialsProject(int id)
        {
            return db.Projects.Find(id);
        }

        public Project GetProjectById(int id)
        {
            return db.Projects.Where(x => x.Id == id).SingleOrDefault();
        }

        public Project GetProjectByUserId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
