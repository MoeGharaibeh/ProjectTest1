using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
   public interface IDeveloperRepository
   {
        public void RejectedStatus(RejectionDto rejectionDto);
        public void EditWorkAPI(EditWorkDto editWork);
        public Models.File GetFileByDeveloper(int id);
        public void AddWorkAPI(AddWorkAPIDto createWork);
        public List<ProjectDeveloper> GetDeveloperProjects(string id);
        public List<Sprint> GetSprint(int id);
        public List<Work> GetWork(string UserId, int TaskId);
        public Work GetWorkById(int id);
        public void EditWork(EditWorkDto editWork);
        public void RemoveWork(Work removeWork);
        public void AddWork(CreateWorkDto createWork);
        public List<Work> GetWorksByDeveloperId(int taskId, string id);

        public List<SprintTask> ShowTaskes(string id);
        public List<SprintTask> GetTaskesBySprintId(int id);

        public void ToggleAllStatus(int id);
        public void checkStatus(string Id);
        public void AddWorkWithSingleFile(CreateWorkDto createWork);

        public Models.File GetDeveloper(int id);


    }
}
