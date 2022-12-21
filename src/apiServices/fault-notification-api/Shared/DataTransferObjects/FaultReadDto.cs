using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public class FaultReadDto
    {
        public Guid Id { get; set; }
        public int PlazaId { get; set; }       
        public int LaneNumber { get; set; }        
        public string? LaneDirection { get; set; }        
        public string? EquipmentType { get; set; }
        public string? Fault_Description { get; set; }
        public string? LaneStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateTimeReported { get; set; }
        public string? ConfirmFaultStatus { get; set; }
        public DateTime? DateTimeConfirmStatus { get; set; }
    }
}
