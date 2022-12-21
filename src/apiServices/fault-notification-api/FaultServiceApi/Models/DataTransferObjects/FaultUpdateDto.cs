using System.ComponentModel.DataAnnotations;

namespace FaultServiceApi.Models.DataTransferObjects
{
    public class FaultUpdateDto
    {     

        [MaxLength(10)]
        public string? ConfirmFaultStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateTimeConfirmStatus { get; set; }
    }
}
