using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject
{
    public class FaultForCreationDto
    {
        [Range(1, 100)]
        public int PlazaId { get; set; }

        [Range(1, 30, ErrorMessage = "Value between 1 and 30")]
        public int LaneNumber { get; set; }

        [MaxLength(3)]
        [Required(ErrorMessage = "Lane Direction is a required field.")]
        public string? LaneDirection { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Equipment Type is a required field.")]
        public string? EquipmentType { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Fault description is a required field.")]
        public string? Fault_Description { get; set; }

        [MaxLength(10)]
        public string? LaneStatus { get; set; }

        [Required(ErrorMessage = "Date Created is a required field.")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "DateTime Reported is a required field.")]
        public DateTime DateTimeReported { get; set; }

    }
}
