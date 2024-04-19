using Landa.RG.DAL.Model;
using Landa.RG.DAL.Service;

namespace Landa.RG.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1) {
                Console.WriteLine(args[0]);
                if (args[0] == "-import") { 
                    var db = new DAL.DAL.LandaDbContext();
                    var service = new RgService(db);

                    string[] espions = File.ReadAllLines(args[1]);
                    for (int i = 0; i < espions.Length; i++)
                    {
                        string[] espionAttributs = espions[i].Split("; ");
                        for (int j = 0; j < espionAttributs.Length; j++)
                        {
                            Console.WriteLine(espionAttributs[j]);
                        }
                        Console.WriteLine(Environment.NewLine);
                        service.AddEspion(espionAttributs[0], espionAttributs[1]);
                    }
                } else if (args[0] == "-mission")
                {
                    var db = new DAL.DAL.LandaDbContext();
                    var service = new RgService(db);

                    var espion = args[1];
                    var lieu = args[2];
                    var annee = args[3];
                }
            }
        }
    }
}
