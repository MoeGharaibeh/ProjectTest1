using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
   public interface ISprintRepository
    {
        public List<Sprint> GetAllSprints(int projectId);
        public List<Sprint> ShowAllSprints();
        public void CreateSprint(CreateSprintDto createSprint);
        public void EditSprint(EditSprintDto editSprint);
        public void RemoveSprint(Sprint RemoveSprint);
        public Sprint DetialsSprint(int id);
        public Sprint GetSprintById(int id);
        public List<Project> GetSprintByTeamLeaderId(string id);
    }
}
