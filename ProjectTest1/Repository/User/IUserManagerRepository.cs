using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository.User
{
    public interface IUserManagerRepository
    {
        public List<ProjectManager> GetAllManagers();
        public Task CreateManager(CreateDto createDto);
        public void EditManager(EditDto editManager);
        public void RemoveProjectManager(ProjectManager RemoveManager);
        public ProjectManager ManagerDetials(string id);

        public ProjectManager GetManagerId(string id);
        public Project GetProjectById(int id);
    }
}
