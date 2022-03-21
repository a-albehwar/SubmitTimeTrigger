using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SubmitTimeTrigger.Interfaces;
using SubmitTimeTrigger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(SubmitTimeTrigger.Startup))]
namespace SubmitTimeTrigger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IHelper, Helper>();
            builder.Services.AddTransient<IAuth, Auth>();
            builder.Services.AddTransient<ITimeEntry, TimeEntry>();
            builder.Services.AddTransient<IValidation, Validation>();
        }
    }
}
