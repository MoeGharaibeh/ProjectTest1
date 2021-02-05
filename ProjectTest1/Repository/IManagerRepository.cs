using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public interface IManagerRepository
    {
        public List<Project> GetProjects(string id);
        public void AddProject(CreateProjectDto createProjectDto);
        public void EditProject(EditProjectDto editProject);
        public void RemoveProject(Project removeProject);
        public List<Sprint> GetSprints(int id);

       
        //public List<Work> GetWorkByDeveloperById(string id);
        public List<Work> GetWorksByDeveloperId(int taskId , string id);
     
        public List<SprintTask> GetSprintTasksBySprintId(int Id);
        public Work GetWorkById(int id);

        //****************STATUS*************
        public void ToggleStatus(int id);





    }
}
