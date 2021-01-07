using AutoMapper;
using LastTask.BL.Interface;
using LastTask.BL.Services;
using LastTask.Controllers;
using LastTask.DL.Interface;
using LastTask.Extensions;
using LastTask.Models.Products;
using LastTask.Models.Request;
using LastTask.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LastTask.Test
{
	public class LaptopTests
	{
		private IMapper _mapper;
		private Mock<ILaptopRepository> _laptopRepository;
		private ILaptopService _laptopService;
		private LaptopController _controller;

		IList<Laptop> _laptop = new List<Laptop>()
			{
				{ new Laptop { LaptopId = 20, LaptopBrand = "Lenovo", LaptopModel = "ThinkPad E14 Gen 2",DateOfManufacturing = new DateTime(2015, 11, 07),Processor = "Intel Core i5-1135G7",GraphicCard = "Intel Iris Xe Graphics",
							 RAM = 8,Battery = "Li-on",Motherboard = "FRU/PN:01HY136",PowerSupply = "X-349H",Memory = "256GB SSD and 2TB HDD" } },
				{ new Laptop {  LaptopId = 18, LaptopBrand = "Acer", LaptopModel = "Aspire 5 (A515-56G)",DateOfManufacturing = new DateTime(2018, 04, 27),Processor = "Intel Core i5-1135G7",GraphicCard = "NVIDIA GeForce MX350",
							 RAM = 20,Battery = "Li-on",Motherboard = "FRU/PN:01H",PowerSupply = "X-349H9DK-2",Memory = "512GB SSD" } },
			};

		public LaptopTests()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapping());
			});

			_mapper = mockMapper.CreateMapper();

			_laptopRepository = new Mock<ILaptopRepository>();


			_laptopService = new LaptopService(_laptopRepository.Object);

			//inject
			_controller = new LaptopController(_laptopService, _mapper);
		}

		[Fact]
		public async Task Laptop_GetAll_Count_Check()
		{
			//setup
			var expectedCount = 2;

			_laptopRepository.Setup(x => x.GetAll())
				.ReturnsAsync(_laptop);

			//Act
			var result = await _controller.GetAll();

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var positions = okObjectResult.Value as IEnumerable<LaptopResponse>;
			Assert.NotNull(positions);
			Assert.Equal(expectedCount, positions.Count());
		}

		[Fact]
		public async Task Laptop_Update_LaptopBrand()
		{
			//setup
			var LaptopId = 20;
			var expectedLaptopBrand = "Dell";

			var position = _laptop.FirstOrDefault(x => x.LaptopId == LaptopId);
			position.LaptopBrand = expectedLaptopBrand;


			_laptopRepository.Setup(x => x.Update(It.IsAny<Laptop>())).Callback(() =>
			{
				position.LaptopBrand = expectedLaptopBrand;
			}).Returns(() => Task<Laptop>.Factory.StartNew(() => new Laptop()
			{
				LaptopId = position.LaptopId,
				LaptopBrand = position.LaptopBrand,
				LaptopModel = position.LaptopModel,
				DateOfManufacturing = position.DateOfManufacturing,
				Processor = position.Processor,
				GraphicCard = position.GraphicCard,
				RAM = position.RAM,
				Battery = position.Battery,
				Motherboard = position.Motherboard,
				PowerSupply = position.PowerSupply,
				Memory = position.Memory,
			}));

			//Act
			var result = await _controller.Update(_mapper.Map<LaptopRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as LaptopResponse;
			Assert.NotNull(pos);
			Assert.Equal(expectedLaptopBrand, pos.LaptopBrand);
		}

		[Fact]
		public async Task Laptop_Delete_Existing_LaptopId()
		{
			//setup
			var LaptopId = 20;

			var position = _laptop.FirstOrDefault(x => x.LaptopId == LaptopId);


			_laptopRepository.Setup(x => x.GetById(LaptopId)).ReturnsAsync(_laptop.FirstOrDefault(x => x.LaptopId == LaptopId));
			_laptopRepository.Setup(x => x.Delete(LaptopId)).Callback(() => _laptop.Remove(position));

			//Act
			var result = await _controller.Delete(LaptopId);

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.Null(okObjectResult);

			Assert.Null(_laptop.FirstOrDefault(x => x.LaptopId == LaptopId));
		}

		[Fact]
		public async Task Laptop_Delete_NotExisting_LaptopId()
		{
			//setup
			var LaptopId = 3;

			var position = _laptop.FirstOrDefault(x => x.LaptopId == LaptopId);


			_laptopRepository.Setup(x => x.Delete(LaptopId)).Callback(() => _laptop.Remove(position));

			//Act
			var result = await _controller.Delete(LaptopId);

			//Assert
			var notFoundObjectResult = result as NotFoundObjectResult;
			Assert.Null(notFoundObjectResult);

			Assert.Null(_laptop.FirstOrDefault(x => x.LaptopId == LaptopId));
		}

		[Fact]
		public async Task Laptop_Create_LaptopBrand()
		{
			//setup
			var position = new Laptop()
			{
				LaptopId = 26,
				LaptopBrand = "HP",
				LaptopModel = "ProBook 450 G7",
				DateOfManufacturing = new DateTime(2020, 10, 12),
				Processor = "Intel Core i7-10510U",
				GraphicCard = "Intel UHD Graphics",
				RAM = 20,
				Battery = "Li-on",
				Motherboard = "Intel H3534",
				PowerSupply = "X-349H",
				Memory = "2TB SSD",

			};

			_laptopRepository.Setup(x => x.Create(It.IsAny<Laptop>())).Callback(() =>
			{
				_laptop.Add(position);
			}).Returns(() => Task<Laptop>.Factory.StartNew(() => new Laptop()
			{
				LaptopId = 26,
				LaptopBrand = "HP",
				LaptopModel = "ProBook 450 G7",
				DateOfManufacturing = new DateTime(2020, 10, 12),
				Processor = "Intel Core i7-10510U",
				GraphicCard = "Intel UHD Graphics",
				RAM = 20,
				Battery = "Li-on",
				Motherboard = "Intel H3534",
				PowerSupply = "X-349H",
				Memory = "2TB SSD",

			}));

			//Act
			var result = await _controller.Create(_mapper.Map<LaptopRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as LaptopResponse;
			Assert.NotNull(pos);

			Assert.NotNull(_laptop.FirstOrDefault(x => x.LaptopId == position.LaptopId));
		}
	}
}
