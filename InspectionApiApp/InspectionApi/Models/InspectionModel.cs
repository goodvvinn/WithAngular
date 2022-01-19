using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectionApi.Models
{
    public class InspectionModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string Status { get; set; } = string.Empty;

        [StringLength(200)]
        public string Comment { get; set; } = string.Empty;

        [ForeignKey("Inspection Type Mode")]
        public int InspectionTypeId { get; set; }
        public InspectionTypeModel? InspectionTypeModel { get; set; }
    }
}
