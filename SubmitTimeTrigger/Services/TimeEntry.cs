using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using SubmitTimeTrigger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitTimeTrigger.Services
{
    public class TimeEntry : ITimeEntry
    {
        private readonly IAuth _auth;
        public TimeEntry(IAuth auth)
        {
            this._auth = auth;

        }
        public Guid AddTimeEntry(DateTime OnStart, DateTime OnEnd)
        {
            using var serviceClient = _auth.Connect("DataVerseConnectionString");
            Guid dupId = Guid.Empty;
            if (serviceClient != null)
            {
                // Service implements IOrganizationService interface 
                if (serviceClient.IsReady)
                {

                    Entity newTimeEntry = new Entity("msdyn_timeentry");

                    newTimeEntry["msdyn_start"] = OnStart;
                    newTimeEntry["msdyn_end"] = OnEnd;
                    newTimeEntry["msdyn_duration"] = "0";
                    //Guid entryGUID = serviceClient.Create(newTimeEntry);

                    // Create operation by suppressing duplicate detection
                    var reqCreate = new CreateRequest();
                    reqCreate.Target = newTimeEntry;
                    reqCreate.Parameters.Add("SuppressDuplicateDetection", false); // Change to false to activate the duplicate detection.

                    CreateResponse createResponse = (CreateResponse)serviceClient.Execute(reqCreate);
                    dupId = createResponse.id;

                }
            }
            return dupId;
        }
    }
}
