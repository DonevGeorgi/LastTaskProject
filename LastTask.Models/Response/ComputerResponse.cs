using System;

namespace LastTask.Models.Response
{
    public class ComputerResponse
    {
        public int ComputerId { set; get; }
        public string ComputerBrand { set; get; }
        public string ComputerModel { set; get; }
        public DateTime DateOfManufacturing { get; set; }
        public string Processor { get; set; }
        public string GraphicCard { get; set; }
        public int RAM { get; set; }
        public string Motherboard { get; set; }
        public string PowerSupply { get; set; }
        public string Memory { get; set; }
        public string ComputerCase { get; set; }
    }
}
