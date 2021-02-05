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
    public class SprintRepository : ISprintRepository
    {
        private ApplicationDbContext db;
        public SprintRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Sprint>ShowAllSprints()
        {
            return db.Sprints.ToList();
        }
        public List<Sprint> GetAllSprints(int projectId)
        {
            return db.Sprints.Include(x => x.Project).Where(x => x.ProjectId == projectId).ToList();
        }
        public void CreateSprint(CreateSprintDto createSprint)
        {
            var sprint = new Sprint()
            {
                Title = createSprint.Title,
                Description = createSprint.Description,

                ProjectId = createSprint.ProjectId,
                TeamleaderId = createSprint.TeamleaderId
                
            };

            sprint.StartDate = DateTime.UtcNow;
            sprint.EndDate = createSprint.EndDate;
            db.Sprints.Add(sprint);
            db.SaveChanges();
        }
        public void EditSprint(EditSprintDto editSprint)
        {
            var sprint = db.Sprints.Where(x=>x.Id == editSprint.Id).SingleOrDefault();
            sprint.Title = editSprint.Title;
            sprint.Description = editSprint.Description;
            sprint.StartDate = editSprint.StartDate;
            sprint.EndDate = editSprint.EndDate;
            db.SaveChanges();
        }
        public void RemoveSprint(Sprint RemoveSprint)
        {
            var sprint = db.Sprints.Where(x => x.Id == RemoveSprint.Id).SingleOrDefault();
            db.Sprints.Remove(sprint);
            db.SaveChanges();
        }

        public Sprint DetialsSprint(int id)
        {
           return db.Sprints.Find(id);

        }

        public Sprint GetSprintById(int id)
        {
            return db.Sprints.Where(x => x.Id == id).SingleOrDefault();
        }

        public List<Project> GetSprintByTeamLeaderId(string id)
        {
            return db.Projects.Include(x=>x.Sprints).Where(x=>x.TeamleaderId == id).ToList();
        }
    }
}
