using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Mover.CandidateTest.Models;
using Mover.CandidateTest.DataAccessObjects;
using Mover.CandidateTest.Application.Services;
using Mover.CandidateTest.Application.ViewModels.WatchHand;
namespace Mover.CandidateTest.Test.UnitTest
{
    [TestClass]
    public class WatchServiceCalculateLeastAngleTest
    { 
        [TestMethod]
        public void CalculateLeastAngleTest00H00MPM()
        {
            IWatchService _watchService = new WatchService();
            double angle = _watchService.GetLeastAngle(0, 00);
            Assert.AreEqual(0, angle);

        }
        [TestMethod]
        public void CalculateLeastAngleTest12H00MPM()
        {
            IWatchService _watchService = new WatchService();
            double angle = _watchService.GetLeastAngle(12, 00);
            Assert.AreEqual(0, angle);

        }
        [TestMethod]
        public void CalculateLeastAngleTest00H30MAM()
        {
            IWatchService _watchService = new WatchService();
            double angle = _watchService.GetLeastAngle(0, 30);
            Assert.AreEqual(165, angle);

        }

        [TestMethod]
        public void CalculateLeastAngleTest12H30MPM()
        {
            IWatchService _watchService = new WatchService();
            double angle = _watchService.GetLeastAngle(12, 30);
            Assert.AreEqual(165, angle);

        }
        [TestMethod]
        public void CalculateLeastAngleTest02H10MPM_FAIL()
        {
            IWatchService _watchService = new WatchService();
            double angle = _watchService.GetLeastAngle(02, 10);
            Assert.AreNotEqual(15, angle);

        }

    }
}
