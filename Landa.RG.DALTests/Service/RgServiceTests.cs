using Microsoft.VisualStudio.TestTools.UnitTesting;
using Landa.RG.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landa.RG.DAL.DAL;
using Moq;

namespace Landa.RG.DAL.Service.Tests
{
    [TestClass()]
    public class RgServiceTests
    {
        [TestMethod()]
        public void RetourneListVideSiAucunEspion()
        {
            //Arrange
            var dbContextMock = new Mock<ILandaDbContext>();
            dbContextMock.Setup(a => a.GetEspions()).Returns(new List<Model.Espion>()
            {
                new Model.Espion("James Bond", "007"),
                new Model.Espion("James Blond", "008"),
                new Model.Espion("James Rond", "009"),
                new Model.Espion("James Pont", "010"),
                new Model.Espion("James Don", "011"),
                new Model.Espion("James Non", "012")
            });

            var service = new RgService(dbContextMock.Object);

            //Act
            var actual = service.GetEspionsByVille("Lille");

            //Assert
            List<Model.Espion> expected = [];
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetourneUnEspion()
        {
            //Arrange
            var dbContextMock = new Mock<ILandaDbContext>();
            dbContextMock.Setup(a => a.GetEspions()).Returns(new List<Model.Espion>()
            {
                new Model.Espion("James Bond", "007"),
                new Model.Espion("James Blond", "008"),
                new Model.Espion("James Rond", "009"),
                new Model.Espion("James Pont", "010"),
                new Model.Espion("James Don", "011"),
                new Model.Espion("James Non", "012")
            });

            dbContextMock.Setup(a => a.GetMissions()).Returns(new List<Model.Mission>()
            {
                new Model.Mission("Toulouse", 1999),
                new Model.Mission("Lille", 2012)
            });

            var service = new RgService(dbContextMock.Object);
            service.AddMissionToEspion(1, dbContextMock.Object.GetMissions()[0]);
            service.AddMissionToEspion(2, dbContextMock.Object.GetMissions()[1]);

            //Act
            var actual = service.GetEspionsByVille("Lille");

            //Assert
            List<Model.Espion> expected = [service.GetEspionById(1)];
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetournePlusieursEspions()
        {
            //Arrange
            var dbContextMock = new Mock<ILandaDbContext>();
            dbContextMock.Setup(a => a.GetEspions()).Returns(new List<Model.Espion>()
            {
                new Model.Espion("James Bond", "007"),
                new Model.Espion("James Blond", "008"),
                new Model.Espion("James Rond", "009"),
                new Model.Espion("James Pont", "010"),
                new Model.Espion("James Don", "011"),
                new Model.Espion("James Non", "012")
            });

            dbContextMock.Setup(a => a.GetMissions()).Returns(new List<Model.Mission>()
            {
                new Model.Mission("Toulouse", 1999),
                new Model.Mission("Lille", 2012)
            });

            var service = new RgService(dbContextMock.Object);
            service.AddMissionToEspion(1, dbContextMock.Object.GetMissions()[1]);
            service.AddMissionToEspion(2, dbContextMock.Object.GetMissions()[1]);
            service.AddMissionToEspion(3, dbContextMock.Object.GetMissions()[1]);
            service.AddMissionToEspion(4, dbContextMock.Object.GetMissions()[0]);

            //Act
            var actual = service.GetEspionsByVille("Lille");

            //Assert
            List<Model.Espion> expected = [service.GetEspionById(1), service.GetEspionById(2), service.GetEspionById(3)];
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}