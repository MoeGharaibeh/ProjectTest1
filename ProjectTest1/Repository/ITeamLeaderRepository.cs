using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public interface ITeamLeaderRepository
    {
        

        public List<Project> GetProjects(string id);
        public List<Sprint> GetSprint(int id);

        public void CreateSprint(CreateSprintDto createSprint);
     
        public void EditSprint(EditSprintDto editSprint);

        public Sprint GetSprintById(int id);


     
        public void CreateSprintTask(CreateTaskDto createTask);
        public void EditTask(EditTaskDto editSprint);
  
     
  

        public List<Project> GetSprintByTeamLeaderId(string id);
       
    
        public SprintTask GetTasksBySprintId(int id);

        public List<Work> GetWorksByDeveloperId(int taskId, string id);
    

        public void TaskStatus(int id);
        public void SprintStatus(int id);
        public void ToggleWorkStatus(int id);
        public void RejectedStatus(RejectionDto rejectionDto);
        public Work GetWorkById(int id);

        public List<ProjectDeveloper> GetDevelopers(int id);

        public void checkStatus(int Id);
   

     
        public List<SprintTask> GetSprintTasksBySprintId(int Id);

        public SprintTask GetSprintTaskById(int id);




    }
}
