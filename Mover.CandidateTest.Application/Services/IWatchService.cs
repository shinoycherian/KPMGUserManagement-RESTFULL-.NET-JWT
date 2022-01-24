

namespace Mover.CandidateTest.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mover.CandidateTest.Application.ViewModels.WatchHand;
    public interface IWatchService
    {

        public double GetLeastAngle(CalculateLeastAngleRequestModel watchhandsmodel);

        public double GetLeastAngle(int hour,int minute );
    }
}
