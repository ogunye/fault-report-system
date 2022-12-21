using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("fault")] 
    public class Fault
    {
        [Column("FaultSerialNumber")]
        public Guid Id { get; set; }

        [Range(1,3, ErrorMessage ="Minimum value is 1, Maximum value is 3")]
        public int PlazaId { get; set; }

        [Range(1, 30, ErrorMessage = "Value between 1 and 30")]
        public int LaneNumber { get; set; }

        [MaxLength(6, ErrorMessage ="Maimum character lenght is 6")]
        [Required(ErrorMessage = "Lane Direction is a required field.")]
        public string? LaneDirection { get; set; }

        [MaxLength(100, ErrorMessage = "Maimum character lenght is 100")]
        [Required(ErrorMessage = "Equipment Type is a required field.")]
        public string? EquipmentType { get; set; }

        [MaxLength(500, ErrorMessage = "Maimum character lenght is 500")]
        [Required(ErrorMessage = "Fault description is a required field.")]
        public string? Fault_Description { get; set; }

        [MaxLength(20, ErrorMessage = "Maimum character lenght is 20")]
        public string? LaneStatus { get; set; }

        [Required(ErrorMessage = "Date Created is a required field.")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "DateTime Reported is a required field.")]
        public DateTime DateTimeReported { get; set; }

        [MaxLength(20, ErrorMessage ="Maximum character length is 20")]
        public string? ConfirmFaultStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateTimeConfirmStatus { get; set; }
    }
}
