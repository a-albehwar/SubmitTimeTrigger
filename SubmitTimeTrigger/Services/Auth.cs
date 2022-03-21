using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Tooling.Connector;
using SubmitTimeTrigger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitTimeTrigger.Services
{
    public class Auth:IAuth
    {
        private readonly IHelper _helper;

        public Auth(IHelper helper)
        {
            this._helper = helper;
        }
        public ServiceClient Connect(string name)
        {
            ServiceClient service = null;
            const string cid = "{c8e69a3e-822b-40b3-a8cb-6b6b9a36b5cb}";
            var connectionString = $@"AuthType=ClientSecret;Url=https://org8ef4b189.crm4.dynamics.com/; ClientId={cid};ClientSecret=R~l7Q~pJ~NCp6quIbOS_qkMgpfZycAnDJO3FT";
            //service = new CrmServiceClient(_helper.GetConnectionStringFromSettings(name));
            service = new ServiceClient(connectionString);

            return service;
        }
    }
}
