using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManagerCore.Models.Tasks
{
    [Table("sm_tasks")]
    public class ServerTask
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TaskType Type { get; set; }
        public int Result { get; set; }
        public DateTime DateJob { get; set; }
        public TimeSpan RepeatingTime { get; set; }
        public bool Repeating { get; set; }
        public int ServerId { get; set; }
    }
}
