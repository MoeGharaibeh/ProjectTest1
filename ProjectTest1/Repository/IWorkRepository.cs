using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public interface IWorkRepository
    {
        public List<Work> GetAllWorks();
        public void CreateWork(CreateWorkDto createWorkDto);
        public void EditWork(EditWorkDto editWork);
        public void RemoveWork(Work RemoveWork);
        public Work DetialsWork(int id);
        public Work GetWorkById(int id);
    }
}
