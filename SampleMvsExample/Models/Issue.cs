using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvsExample.Models
{
    public class Issue : BaseModels
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int? ExecutorId { get; set; }
        public int PrioritiesId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual User? Author { get; set; }
        [ForeignKey(nameof(ExecutorId))]
        public virtual User? Executor { get; set; }
        [ForeignKey(nameof(PrioritiesId))]
        public virtual Priorities? Priorities { get; set; }
        public virtual ICollection<TimeTracking> TimeTrackings { get; set; }

        public Issue()
        {
            TimeTrackings = new List<TimeTracking>();
        }
    }

}
