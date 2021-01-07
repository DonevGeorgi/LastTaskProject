using System;

namespace LastTask.Models.Response
{
    public class LaptopResponse
    {
        public int LaptopId { get; set; }
        public string LaptopBrand { get; set; }
        public string LaptopModel { get; set; }
        public DateTime DateOfManufacturing { get; set; }
        public string Processor { get; set; }
        public string GraphicCard { get; set; }
        public int RAM { get; set; }
        public string Battery { get; set; }
        public string Motherboard { get; set; }
        public string Memory { get; set; }
        public string PowerSupply { get; set; }
    }
}
