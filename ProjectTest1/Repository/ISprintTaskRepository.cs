using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public interface ISprintTaskRepository
    {
        public List<SprintTask> GetAllTasks();
        public void CreateSprintTask(CreateTaskDto createTask);
        public void EditTask(EditTaskDto editSprint);
        public void RemoveTask(SprintTask RemoveTask);
        public SprintTask DetialsTask(int id);
        public SprintTask GetTaskById(int id);
      
    }
}
