using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject
{
    public class FaultForUpdateDto
    {
        [MaxLength(10)]
        public string? ConfirmFaultStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateTimeConfirmStatus { get; set; }
    }
}
