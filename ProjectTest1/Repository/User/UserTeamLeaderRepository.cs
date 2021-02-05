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
    public class UserTeamLeaderRepository : IUserTeamLeaderRepository
    {

        private ApplicationDbContext db;
        private UserManager<IdentityUser> userManager;
        public UserTeamLeaderRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task CreateTeamLeader(CreateDto createTeamLeaderDto)
        {
            var teamLeader = new TeamLeader()
            {
                FirstName = createTeamLeaderDto.FirstName,
                LastName = createTeamLeaderDto.LastName,
                UserName = createTeamLeaderDto.UserName,
                Email = createTeamLeaderDto.UserName,
                PhoneNumber = createTeamLeaderDto.PhoneNumber,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(teamLeader, createTeamLeaderDto.Password);
            if (result.Succeeded)
            {
                db.UserRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = teamLeader.Id,
                    RoleId = "2"
                });
                db.SaveChanges();

            }
            else
            {

            }
        }

        public void EditTeamLeader(EditDto editTeamLeader)
        {
            var teamLeader = db.TeamLeaders.Where(x => x.Id == editTeamLeader.Id).SingleOrDefault();

            teamLeader.FirstName = editTeamLeader.FirstName;
            teamLeader.LastName = editTeamLeader.LastName;
            teamLeader.UserName = editTeamLeader.UserName;
            teamLeader.Email = editTeamLeader.UserName;
            teamLeader.PhoneNumber = editTeamLeader.PhoneNumber;
            db.SaveChanges();
        }

        public List<TeamLeader> GetAllTeamLeaders()
        {
            return db.TeamLeaders.ToList();

        }
        public TeamLeader DetialsTeamLeader(string id)
        {
            return db.TeamLeaders.Find(id);
        }

        public TeamLeader GetTeamLeaderId(string id)
        {
            return db.TeamLeaders.Where(x => x.Id == id).SingleOrDefault();

        }

        public void RemoveTeamLeader(TeamLeader RemoveLeader)
        {
            var teamLeader = db.TeamLeaders.Where(x => x.Id == RemoveLeader.Id).SingleOrDefault();
            db.TeamLeaders.Remove(teamLeader);
            db.SaveChanges();

         

        }




    }
}
