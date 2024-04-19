using System.ComponentModel.DataAnnotations;

namespace Landa.RG.DAL.Model
{
    public class Espion
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Nom { get; set; }

        [MaxLength(50)]
        public string Code { get; set;}
        public List<Mission> Missions { get; set; }
        public Espion(string nom, string code) {
            Nom = nom;
            Code = code;
        }
    }
}
