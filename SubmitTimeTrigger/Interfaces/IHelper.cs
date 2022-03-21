using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitTimeTrigger.Interfaces
{
    public interface IHelper
    {
        public string GetConnectionStringFromSettings(string name);
    }
}
