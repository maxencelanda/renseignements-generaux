using Landa.RG.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landa.RG.DAL.DAL
{
    public class LandaDbContext : DbContext, ILandaDbContext
    {
        public DbSet<Espion> Espions { get; set; }
        public DbSet<Mission> Missions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=rg;Uid=root;Pwd=;";
            var serverVersion = new MySqlServerVersion(new Version(10, 4, 32));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public List<Espion> GetEspions()
        {
            return Espions.ToList();
        }

        public Espion GetEspionById(int id)
        {
            return this.Espions.Find(id);
        }

        public Espion AddEspion(string nom, string code)
        {
            Espion espion = new Espion(nom, code);
            Espions.Add(espion);
            SaveChanges();
            return espion;
        }

        public List<Mission> GetMissions()
        {
            return Missions.ToList();
        }

        public Mission AddMission(string lieu, int annee)
        {
            Mission mission = new Mission(lieu, annee);
            this.Missions.Add(mission);
            SaveChanges();
            return mission;
        }

        public void AddMissionToEspion(int idEspion, Mission mission)
        {
            Espion espion = this.Espions.Find(idEspion);
            espion.Missions.Add(mission);
            SaveChanges();
        }
    }
}
