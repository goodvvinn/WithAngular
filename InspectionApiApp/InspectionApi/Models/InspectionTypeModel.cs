using System.ComponentModel.DataAnnotations;

namespace InspectionApi.Models
{
    public class InspectionTypeModel
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(30)]
        public string InspectionName { get; set; } = string.Empty;
    }
}
