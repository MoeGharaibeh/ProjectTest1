using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public interface IprojectRepository
    {
        
        public void CreateProject(CreateProjectDto createProjectDto);
        public void EditProject(EditProjectDto editProject);
        public void RemoveProject(Project RemoveProject);
        public Project DetialsProject(int id);
        public Project GetProjectById(int id);
        public List<Project> GetAllProjects(string id);
        public Project GetProjectByUserId(string id);
    }
}
