using Microsoft.Xrm.Tooling.Connector;
using SubmitTimeTrigger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SubmitTimeTrigger.Services
{
    public class Helper : IHelper
    {
        private readonly IConfiguration _configuration;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionStringFromSettings(string name)
        {

            return _configuration.GetConnectionString(name);

        }
    }
}
