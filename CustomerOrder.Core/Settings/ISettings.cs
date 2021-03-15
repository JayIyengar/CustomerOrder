using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Core.Settings
{
    public interface ISettings
    {
        string CustomerDetailApiUrl { get; set; }
        string ApiKey { get; set; }
        string DbConnectionString { get; set; }
    }
}
