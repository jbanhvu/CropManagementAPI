namespace CropManagement.Models
{
    public class MachineOperatingLog
    {
        public Int32 MachineOperatingLogID { get; set; }
        public DateTime MachineOperatingDate { get; set; }
        public String MachineInspectionStatus { get; set; }
        public String OperaterUser { get; set; }
        public String SupervisorUser { get; set; }
        public String Note { get; set; }

    }
}
