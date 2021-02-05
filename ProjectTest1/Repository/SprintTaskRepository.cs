using ProjectTest1.Data;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public class SprintTaskRepository : ISprintTaskRepository
    {
        private ApplicationDbContext db;
        public SprintTaskRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateSprintTask(CreateTaskDto createTask)
        {
            var task = new SprintTask
            {
                Title = createTask.Title,
                Description = createTask.Description
            };
            db.SprintTasks.Add(task);
            db.SaveChanges();
        }

        public SprintTask DetialsTask(int id)
        {
            return db.SprintTasks.Find(id);
        }

        public void EditTask(EditTaskDto editSprint)
        {
            var task = db.SprintTasks.Where(x => x.Id == editSprint.Id).SingleOrDefault();
            task.Title = editSprint.Title;
            task.Description = editSprint.Description;
            db.SaveChanges();
        }

        public List<SprintTask> GetAllTasks()
        {
            return db.SprintTasks.ToList();
        }

        public SprintTask GetTaskById(int id)
        {
            return db.SprintTasks.Where(x => x.Id == id).SingleOrDefault();
        }

        public void RemoveTask(SprintTask RemoveTask)
        {
            var task = db.SprintTasks.Where(x => x.Id == RemoveTask.Id).SingleOrDefault();
            db.SprintTasks.Remove(task);
            db.SaveChanges();
        }
    }
}
