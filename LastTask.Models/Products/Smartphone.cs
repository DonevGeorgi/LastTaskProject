using System;

namespace LastTask.Models.Products
{
    public class Smartphone
    {
        public int SmartphoneId { get; set; }
        public string SmartphoneBrand { get; set; }
        public string SmartphoneModel { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public string Inch { get; set; }
        public string BackCameraMP { get; set; }
        public string FrontCameraMP { get; set; }
        public string Memory { get; set; }
        public string BaterymAh { get; set; }
    }
}
