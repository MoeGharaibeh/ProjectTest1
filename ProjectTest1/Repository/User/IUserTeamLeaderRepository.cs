using ProjectTest1.Dto;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Repository.User
{
    public interface IUserTeamLeaderRepository
    {
        public List<TeamLeader> GetAllTeamLeaders();
        public Task CreateTeamLeader(CreateDto createTeamLeaderDto);
        public void EditTeamLeader(EditDto editTeamLeader);
        public void RemoveTeamLeader(TeamLeader RemoveTeamLeader);
        public TeamLeader DetialsTeamLeader(string id);

        public TeamLeader GetTeamLeaderId(string id);
        



    }
}
