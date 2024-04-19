namespace Landa.RG.DAL.Model
{
    public class Mission
    {
        public int Id { get; set; }
        public string Lieu {  get; set; }
        public int Annee { get; set; }

        public Mission(string lieu, int annee)
        {
            Lieu = lieu;
            Annee = annee;
        }
    }
}
