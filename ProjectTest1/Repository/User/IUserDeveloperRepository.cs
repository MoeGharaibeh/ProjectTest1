using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository.User
{
   public interface IUserDeveloperRepository
    {
        public List<Developer> GetAllDevelopers();
        public Task CreateDeveloper(CreateDto createDeveloperDto);
        public void EditDeveloper(EditDto editDeveloper);
        public void RemoveDeveloper(Developer RemoveDeveloper);
        public Developer DetialsDeveloper(string id);
        public Developer GetDeveloperId(string id);
       
    }
}
