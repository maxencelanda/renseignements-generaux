using Landa.RG.DAL.DAL;
using Landa.RG.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landa.RG.DAL.Service
{
    public class RgService : IRgService
    {
        private ILandaDbContext _dbContext { get; set; }

        public RgService(ILandaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Espion AddEspion(string nom, string code)
        {
            return _dbContext.AddEspion(nom, code);
        }

        public List<Espion> GetEspions()
        {
            return _dbContext.GetEspions();
        }

        public Espion GetEspionById(int id)
        {
            return _dbContext.GetEspionById(id);
        }

        public List<Espion> GetEspionsByVille(string ville)
        {
            var espions = _dbContext.GetEspions();
            List<Espion> espionsDansVille = [];
            for (int i = 0; i < espions.Count; i++)
            {
                if (espions[i].Missions != null) {
                    for (int j = 0; j < espions[i].Missions.Count; j++)
                    {
                        if (espions[i].Missions[j].Lieu == ville)
                        {
                            espionsDansVille.Add(espions[i]);
                            break;
                        }
                    }
                }
            }
            return espionsDansVille;
        }

        public void AddMission(string lieu, int annee)
        {
            _dbContext.AddMission(lieu, annee);
        }

        public void AddMissionToEspion(int id, Mission mission)
        {
            _dbContext.AddMissionToEspion(id, mission);
        }

        public List<Mission> GetMissions()
        {
            return _dbContext.GetMissions();
        }
    }
}
