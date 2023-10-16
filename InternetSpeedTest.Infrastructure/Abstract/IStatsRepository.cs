using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetSpeedTest.Infrastructure.Models.Dto;

namespace InternetSpeedTest.Infrastructure.Abstract
{
    public interface IStatsRepository
    {
        Task<List<HistoryDto>> GetHistoryAsync(string userId);
        Task<ResultDto> GetResultsAsync(string location);
    }
}