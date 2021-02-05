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
    public class UserDeveloperRepository : IUserDeveloperRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public UserDeveloperRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }



        public async Task CreateDeveloper(CreateDto createDeveloperDto)
        {
            var Dev = new Developer()
            {
                FirstName = createDeveloperDto.FirstName,
                LastName = createDeveloperDto.LastName,
                UserName = createDeveloperDto.UserName,
                Email = createDeveloperDto.UserName,
                PhoneNumber = createDeveloperDto.PhoneNumber,
                EmailConfirmed = true

            };
            var result = await userManager.CreateAsync(Dev, createDeveloperDto.Password);
            if (result.Succeeded)
            {
                db.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = Dev.Id,
                    RoleId = "3"
                });
                db.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public void EditDeveloper(EditDto editDeveloper)
        {

            var Dev = db.Developers.Where(x => x.Id == editDeveloper.Id).SingleOrDefault();
            Dev.FirstName = editDeveloper.FirstName;
            Dev.LastName = editDeveloper.LastName;
            Dev.UserName = editDeveloper.UserName;
            Dev.Email = editDeveloper.UserName;
            Dev.PhoneNumber = editDeveloper.PhoneNumber;
            db.SaveChanges();
        }

        public List<Developer> GetAllDevelopers()
        {
            return db.Developers.ToList();
        }
        public Developer DetialsDeveloper(string id)
        {
            return db.Developers.Find(id);
        }
        public Developer GetDeveloperId(string id)
        {
            return db.Developers.Where(x => x.Id == id).SingleOrDefault();
        }

        public void RemoveDeveloper(Developer RemoveDeveloper)
        {
            var developer = db.Developers.Where(x => x.Id == RemoveDeveloper.Id).SingleOrDefault();
            db.Developers.Remove(developer);
            db.SaveChanges();

            //var project = db.ProjectDevelopers.Where(x => x.ProjectId = x.DeveloperId).ToList();
            //foreach (var item in project)
            //{
            //    db.ProjectDevelopers.Remove(item);
            //}
            //db.SaveChanges();

        }
    }
}
