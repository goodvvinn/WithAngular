using System.ComponentModel.DataAnnotations;

namespace InspectionApi.Models
{
    public class StatusModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string Status { get; set; } = string.Empty;  
    }
}
