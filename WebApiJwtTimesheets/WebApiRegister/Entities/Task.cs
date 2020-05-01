using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRegister.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public ICollection<TimesheetRow> TimesheetRows { get; set; }
        
    }
}
