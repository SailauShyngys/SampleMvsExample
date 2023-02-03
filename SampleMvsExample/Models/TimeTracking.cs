using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvsExample.Models
{
    public class TimeTracking : BaseModels
    {
        public int? UserId { get; set; }
        public int IssueId { get; set; }
        public DateTime ExecutionDate { get; set; }

        public int Hours { get; set; }
        [ForeignKey(nameof(IssueId))]
        public virtual Issue Issue { get; set; }

    }
}
