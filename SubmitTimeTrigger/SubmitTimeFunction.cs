using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.PowerPlatform.Dataverse.Client;
using SubmitTimeTrigger.Interfaces;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using SubmitTimeTrigger.Model;

namespace SubmitTimeTrigger
{
    public class SubmitTimeFunction
    {
        private readonly IHelper _helper;
        private readonly IAuth _auth;
        private readonly IValidation _validation;
        private readonly ITimeEntry _entrytime;
        public SubmitTimeFunction(IHelper helper,IAuth auth, IValidation validation,ITimeEntry entrytime)
        {
            this._helper = helper;
            this._auth=auth;
            this._validation=validation;
            this._entrytime = entrytime;
        }

        [FunctionName("TimeFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {           
            try
            {
                // read the contents of the posted data into a string
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                // use Json.NET to deserialize the posted JSON into a C# object
                TimeEntryModel data = JsonConvert.DeserializeObject<TimeEntryModel>(requestBody);

                Guid guid=_entrytime.AddTimeEntry(data.StartOn, data.EndOn);              
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return new OkObjectResult(ex.Message);
            }

            return new OkObjectResult("Success");
        }
    }
}
