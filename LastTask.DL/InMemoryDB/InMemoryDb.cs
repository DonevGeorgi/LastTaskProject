using LastTask.Models.Products;
using System;
using System.Collections.Generic;

namespace Project.DL.InMemoryDB
{
    public static class InMemoryDb
    {
        public static List<Computer> Computers { get; set; } = new List<Computer>();
        public static List<Laptop> Laptops { get; set; } = new List<Laptop>();
        public static List<Smartphone> Smartphones { get; set; } = new List<Smartphone>();
        public static List<Televisor> Televisors { get; set; } = new List<Televisor>();
        public static void Init()
        {
            //Computer
            Computers.Add(new Computer
            {
                ComputerId = 723456,
                ComputerBrand = "ALIENWARE",
                ComputerModel = "Aurora R10",
                DateOfManufacturing = new DateTime(2020, 02, 03),
                Processor = "AMD Ryzen™ 9 3950X",
                GraphicCard = "NVIDIA® GeForce® RTX 2080 Ti 11GB",
                RAM = 32,
                Motherboard = "A 3950X Invasion",
                PowerSupply = "1000W",
                Memory = "SSD 512GB and HDD 1TB",
                ComputerCase = "Middle Tower"

            });

            //Laptop
            Laptops.Add(new Laptop
            {
                LaptopId = 214678,
                LaptopBrand = "ASUS",
                LaptopModel = "Nitro 5",
                DateOfManufacturing = new DateTime(2020, 11, 09),
                Processor = "Intel® Core™ i7-10750H 2.6 GHz - 5.0 GHz, 12MB cache (6-cores)",
                GraphicCard = "NVIDIA GeForce GTX 1650 Ti (4GB GDDR6)",
                RAM = 16,
                Battery = "4-клетъчна Li-ion 3220 mAh 8.50 Hour",
                Motherboard = "HM175",
                PowerSupply = "MaxPower 135 W",
                Memory = "HDD 1000 GB and SDD 500GB"
            });

            //Smartphone
            Smartphones.Add(new Smartphone
            {
                SmartphoneId = 168742,
                SmartphoneBrand = "Xiaomi",
                SmartphoneModel = "Redmi Note 9",
                DateOfManufacturing = new DateTime(2020, 05, 30),
                Inch = "6.53 inch",
                BackCameraMP = "48 MP WideAngle",
                FrontCameraMP = "13 MP",
                Memory = "128GB",
                BaterymAh = "Li-Po 5020 mAh"
            });

            //Televisor
            Televisors.Add(new Televisor
            {
                TelevisorId = 790003,
                TelevisorBrand = "Samsung",
                TelevisorModel = "82TU8072",
                DateOfManufacturing = new DateTime(2020, 03, 21),
                TelevisorCategory = "LED",
                Inch = "82(207cm) inch",
                Resolution = "4K UltraHD (3840 x 2160)",
            });
        }
    }

}
