using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetSpeedTest.Infrastructure.Models.Dto
{
    public class HistoryDto
    {
        public DateTime Date { get; set; }
        public double DownloadSpeed { get; set; }
        public double UploadSpeed { get; set; }
    }
}