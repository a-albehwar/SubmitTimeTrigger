using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitTimeTrigger.Interfaces
{
    public interface ITimeEntry
    {
        public Guid AddTimeEntry(DateTime OnStart, DateTime OnEnd);
    }
}
