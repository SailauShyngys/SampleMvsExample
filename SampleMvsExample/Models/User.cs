using System.ComponentModel.DataAnnotations.Schema;

namespace SampleMvsExample.Models
{
    public class User : BaseModels
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PositionId { get; set; }

        
        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; }
    }
} 
