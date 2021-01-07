using System;

namespace LastTask.Models.Request
{
    public class TelevisorRequest
    {
        public int TelevisorId { get; set; }
        public string TelevisorBrand { get; set; }
        public string TelevisorModel { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public string TelevisorCategory { get; set; }
        public string Inch { get; set; }
        public string Resolution { get; set; }
    }
}
