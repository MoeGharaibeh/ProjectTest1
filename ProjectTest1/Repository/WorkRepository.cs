using ProjectTest1.Data;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository
{
    public class WorkRepository : IWorkRepository
    {
        private ApplicationDbContext db;
        public WorkRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Work> GetAllWorks()
        {
            return db.Works.ToList();
        }
        public void CreateWork(CreateWorkDto createWorkDto)
        {
            var work = new Work()
            {
                Title = createWorkDto.Title,
                Description = createWorkDto.Description 
            };
            db.Add(work);
            db.SaveChanges();
            
        }
        public void EditWork(EditWorkDto editWork)
        {
            var work = db.Works.Where(x => x.Id == editWork.Id).SingleOrDefault();
            work.Title = editWork.Title;
            work.Description = editWork.Description;
            db.SaveChanges();
        }
        public void RemoveWork(Work RemoveWork)
        {
            var work = db.Works.Where(x => x.Id == RemoveWork.Id).SingleOrDefault();
            db.Remove(work);
            db.SaveChanges();
        }
        public Work GetWorkById(int id)
        {
            return db.Works.Where(x=>x.Id == id).SingleOrDefault();

        }

   
        public Work DetialsWork(int id)
        {
            return db.Works.Find(id);
        }
    }
}
