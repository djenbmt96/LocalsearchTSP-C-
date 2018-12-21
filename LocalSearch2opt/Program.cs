using LocalSearchTSP.Processors;
using LocalSearchTSP.Services;
using LocalSearchTSP.Services.Implements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearchTSP
{
    class Program
    {
        static void Main(string[] args)
        {
            ILocalSearchService localSearchService = new LocalSearchService();
            I2OptService _2OptService = new _2OptService(localSearchService);
            LocalSearchProcessor processor = new LocalSearchProcessor(localSearchService, _2OptService);
            processor.Run();
        }
    }
}
