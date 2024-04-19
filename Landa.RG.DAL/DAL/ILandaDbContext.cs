using Landa.RG.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Landa.RG.DAL.DAL
{
    public interface ILandaDbContext
    {
        DbSet<Espion> Espions { get; set; }
        DbSet<Mission> Missions { get; set; }

        public List<Espion> GetEspions();
        public Espion GetEspionById(int id);
        public Espion AddEspion(string nom, string code);
        public List<Mission> GetMissions();
        public Mission AddMission(string lieu, int annee);
        public void AddMissionToEspion(int idEspion, Mission mission);
    }
}