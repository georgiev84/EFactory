using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRegister.Entities
{
    public class Timesheet
    {
        public int Id { get; set; }
        public string WeekTitle { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<TimesheetRow> TimesheetRows { get; set; }

    }
}
