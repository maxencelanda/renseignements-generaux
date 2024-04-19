using Landa.RG.DAL.Model;

namespace Landa.RG.DAL.Service
{
    public interface IRgService
    {
        public Espion AddEspion(string nom, string code);
        public List<Espion> GetEspions();
        public Espion GetEspionById(int id);
        public List<Mission> GetMissions();
        public void AddMission(string lieu, int annee);
        public void AddMissionToEspion(int id, Mission mission);
    }
}