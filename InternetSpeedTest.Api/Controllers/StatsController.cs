using InternetSpeedTest.Infrastructure.Abstract;
using InternetSpeedTest.Infrastructure.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InternetSpeedTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsRepository _statsRepository;

        public StatsController(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        [HttpGet]
        [Route("userId/history")]
        public Task<List<HistoryDto>> GetHistory(string userId)
        {
            return _statsRepository.GetHistoryAsync(userId);
        }

        [HttpGet]
        [Route("ISP")]
        public Task<ResultDto> GetISP(string location)
        {
            return _statsRepository.GetResultsAsync(location);
        }
    }
}