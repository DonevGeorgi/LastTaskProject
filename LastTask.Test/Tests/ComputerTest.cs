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
    public class ComputerTests
	{
		private IMapper _mapper;
		private Mock<IComputerRepository> _computerRepository;
		private IComputerService _computerService;
		private ComputerController _controller;

		IList<Computer> _computer = new List<Computer>()
			{
				{ new Computer {   ComputerId = 25,ComputerBrand = "Dell",ComputerModel = "vostro 3888 MT",DateOfManufacturing = new DateTime(2016, 01, 24),Processor = "Intel Core i5-10400",GraphicCard = "Intel UHD Graphics 630",
							 RAM = 16,Motherboard = "Intel B460",PowerSupply = "250W",Memory = "HDD 1TB", ComputerCase = "Dell Dimension 240" } },
				{ new Computer {   ComputerId = 28,ComputerBrand = "Dell",ComputerModel = "vostro 3888 MT",DateOfManufacturing = new DateTime(2016, 06, 30),Processor = "Intel Core i5-10400",GraphicCard = "Intel UHD Graphics 630",
							 RAM = 32,Motherboard = "Intel B460",PowerSupply = "200W",Memory = "HDD 3TB", ComputerCase = "Dell Dimension 200" } },
			};

		public ComputerTests()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapping());
			});

			_mapper = mockMapper.CreateMapper();

			_computerRepository = new Mock<IComputerRepository>();


			_computerService = new ComputerService(_computerRepository.Object);

			//inject
			_controller = new ComputerController(_computerService, _mapper);
		}

		[Fact]
		public async Task Computer_GetAll_Count_Check()
		{
			//setup
			var expectedCount = 2;

			_computerRepository.Setup(x => x.GetAll())
				.ReturnsAsync(_computer);

			//Act
			var result = await _controller.GetAll();

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var positions = okObjectResult.Value as IEnumerable<ComputerResponse>;
			Assert.NotNull(positions);
			Assert.Equal(expectedCount, positions.Count());
		}

		[Fact]
		public async Task Computer_Update_ComputerBrand()
		{
			//setup
			var ComputerId = 25;
			var expectedComputerBrand = "New Computer Brand";

			var position = _computer.FirstOrDefault(x => x.ComputerId == ComputerId);
			position.ComputerBrand = expectedComputerBrand;


			_computerRepository.Setup(x => x.Update(It.IsAny<Computer>())).Callback(() =>
			{
				position.ComputerBrand = expectedComputerBrand;
			}).Returns(() => Task<Computer>.Factory.StartNew(() => new Computer()
			{
				ComputerId = position.ComputerId,
				ComputerBrand = position.ComputerBrand,
				ComputerModel = position.ComputerModel,
				DateOfManufacturing = position.DateOfManufacturing,
				Processor = position.Processor,
				GraphicCard = position.GraphicCard,
				RAM = position.RAM,
				Motherboard = position.Motherboard,
				PowerSupply = position.PowerSupply,
				Memory = position.Memory,
				ComputerCase = position.ComputerCase
			}));

			//Act
			var result = await _controller.Update(_mapper.Map<ComputerRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as ComputerResponse;
			Assert.NotNull(pos);
			Assert.Equal(expectedComputerBrand, pos.ComputerBrand);
		}

		[Fact]
		public async Task Computer_Delete_Existing_ComputerId()
		{
			//setup
			var ComputerId = 25;

			var position = _computer.FirstOrDefault(x => x.ComputerId == ComputerId);


			_computerRepository.Setup(x => x.GetById(ComputerId)).ReturnsAsync(_computer.FirstOrDefault(x => x.ComputerId == ComputerId));
			_computerRepository.Setup(x => x.Delete(ComputerId)).Callback(() => _computer.Remove(position));

			//Act
			var result = await _controller.Delete(ComputerId);

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.Null(okObjectResult);

			Assert.Null(_computer.FirstOrDefault(x => x.ComputerId == ComputerId));
		}

		[Fact]
		public async Task Computer_Delete_NotExisting_ComputerId()
		{
			//setup
			var ComputerId = 3;

			var position = _computer.FirstOrDefault(x => x.ComputerId == ComputerId);


			_computerRepository.Setup(x => x.Delete(ComputerId)).Callback(() => _computer.Remove(position));

			//Act
			var result = await _controller.Delete(ComputerId);

			//Assert
			var notFoundObjectResult = result as NotFoundObjectResult;
			Assert.Null(notFoundObjectResult);

			Assert.Null(_computer.FirstOrDefault(x => x.ComputerId == ComputerId));
		}

		[Fact]
		public async Task Computer_Create_ComputerBrand()
		{
			//setup
			var position = new Computer()
			{
				ComputerId = 26,
				ComputerBrand = "Lenovo",
				ComputerModel = "V530s SFF",
				DateOfManufacturing = new DateTime(2020, 11, 13),
				Processor = "Intel Core i9-9900",
				GraphicCard = "Intel UHD Graphics 630",
				RAM = 32,
				Motherboard = "Intel B365",
				PowerSupply = "500W",
				Memory = "SSD 512GB and HDD 1TB",
				ComputerCase = "Lenovo Tower Desktop"

			};

			_computerRepository.Setup(x => x.Create(It.IsAny<Computer>())).Callback(() =>
			{
				_computer.Add(position);
			}).Returns(() => Task<Computer>.Factory.StartNew(() => new Computer()
			{
				ComputerId = 26,
				ComputerBrand = "Lenovo",
				ComputerModel = "V530s SFF",
				DateOfManufacturing = new DateTime(2020, 11, 13),
				Processor = "Intel Core i9-9900",
				GraphicCard = "Intel UHD Graphics 630",
				RAM = 32,
				Motherboard = "Intel B365",
				PowerSupply = "500W",
				Memory = "SSD 512GB and HDD 1TB",
				ComputerCase = "Lenovo Tower Desktop"

			}));

			//Act
			var result = await _controller.Create(_mapper.Map<ComputerRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as ComputerResponse;
			Assert.NotNull(pos);

			Assert.NotNull(_computer.FirstOrDefault(x => x.ComputerId == position.ComputerId));
		}
	}
}
