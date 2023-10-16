using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetSpeedTest.Infrastructure.Abstract
{
    public interface IDownloadTestFile
    {
        Task<FileAccess> GetFileAsync();
    }
}