
namespace MoverCandidateTest.Controllers.WatchHands
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using Mover.CandidateTest.Application.ViewModels;
    using Mover.CandidateTest.Application.Services;
    using Mover.CandidateTest.Application.ViewModels.WatchHand;
    [ApiController]
    [Route("[controller]")]
    public class CalculateLeastAngleController : ControllerBase
    {
        private readonly ILogger<CalculateLeastAngleController> _logger;
        private readonly IWatchService _watchService;

        public CalculateLeastAngleController(ILogger<CalculateLeastAngleController> logger,IWatchService watchservice)
        {
            this._logger = logger;
            this._watchService = watchservice;
        }

        [HttpGet]
        public string Get([FromQuery] CalculateLeastAngleRequestModel requestModel)
        {
            double angle=_watchService.GetLeastAngle(requestModel);
            return $" OUTPT : : The Least angle : {angle} deg.:) (Input reads: {requestModel.DateTime})";
        }
    }
}
