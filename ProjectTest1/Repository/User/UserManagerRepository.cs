using Microsoft.AspNetCore.Identity;
using ProjectTest1.Data;
using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository.User
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;

        public UserManagerRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task CreateManager(CreateDto createManagerDto)
        {
            var manager = new ProjectManager
            {
                FirstName = createManagerDto.FirstName,
                LastName = createManagerDto.LastName,
                UserName = createManagerDto.UserName,
                Email = createManagerDto.UserName,
                PhoneNumber = createManagerDto.PhoneNumber,
                EmailConfirmed = true


            };
            db.SaveChanges();



            var result = await userManager.CreateAsync(manager, createManagerDto.Password);

            if (result.Succeeded)
            {
                db.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = manager.Id,
                    RoleId = "1"
                });
                db.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }


        public void EditManager(EditDto editManager)
        {
            var manager = db.ProjectManagers.Where(x => x.Id == editManager.Id).SingleOrDefault();

            manager.FirstName = editManager.FirstName;
            manager.LastName = editManager.LastName;
            manager.UserName = editManager.UserName;
            manager.PhoneNumber = editManager.PhoneNumber;
            manager.EmailConfirmed = true;
            db.SaveChanges();
        }



        public List<ProjectManager> GetAllManagers()
        {
            return db.ProjectManagers.ToList();
        }

        public ProjectManager GetManagerId(string id)
        {
            return db.ProjectManagers.SingleOrDefault(x => x.Id == id);
        }

        public void RemoveProjectManager(ProjectManager RemoveManager)
        {
            var manager = db.ProjectManagers.Where(x => x.Id == RemoveManager.Id).SingleOrDefault();
            db.ProjectManagers.Remove(manager);
            db.SaveChanges();

        }

        public ProjectManager ManagerDetials(string id)
        {
            return db.ProjectManagers.Find(id);
        }

        public Project GetProjectById(int id)
        {
        
            return db.Projects.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
