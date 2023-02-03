using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SampleMvsExample.Models
{
    public abstract class BaseModels
    {
        [Key]
        public int id { get; set; }
        public DateTime CreateId { get; set; }  
        public DateTime? ModifiedId { get; set; }   

    }
}
