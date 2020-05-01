using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRegister.Entities
{
    public class TimesheetRow
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public float MondayHours { get; set; }
        public float TuesdayHours { get; set; }
        public float WednesdayHours { get; set; }
        public float ThursdayHours { get; set; }
        public float FridayHours { get; set; }
        public int TimesheetId { get; set; }
        public Timesheet Timesheet { get; set; }
        public Task Task { get; set; }
        public Project Project { get; set; }
    }
}
