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
	public class SmartphoneTests
	{
		private IMapper _mapper;
		private Mock<ISmartphoneRepository> _smartphoneRepository;
		private ISmartphoneService _smartphoneService;
		private SmartphoneController _controller;

		IList<Smartphone> _smartphone = new List<Smartphone>()
			{
				{ new Smartphone { SmartphoneId = 15, SmartphoneBrand = "Xiaomi", SmartphoneModel = "MI 10", DateOfManufacturing = new DateTime(2019, 11, 15), Inch = "6.67",BackCameraMP ="108 MP + 13 MP + 2 MP + 2 MP",
				FrontCameraMP= "20 MP",Memory = "128GB",BaterymAh = "4780 mAh"} },
				{ new Smartphone {  SmartphoneId = 13 ,SmartphoneBrand = "Apple", SmartphoneModel = "iPhone 11", DateOfManufacturing = new DateTime(2019, 07, 27), Inch = "6.1",BackCameraMP ="12MP",
				FrontCameraMP= "12MP",Memory = "256GB",BaterymAh = "3110 mAh" } },
			};

		public SmartphoneTests()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapping());
			});

			_mapper = mockMapper.CreateMapper();

			_smartphoneRepository = new Mock<ISmartphoneRepository>();


			_smartphoneService = new SmartphoneService(_smartphoneRepository.Object);

			//inject
			_controller = new SmartphoneController(_smartphoneService, _mapper);
		}

		[Fact]
		public async Task Smartphone_GetAll_Count_Check()
		{
			//setup
			var expectedCount = 2;

			_smartphoneRepository.Setup(x => x.GetAll())
				.ReturnsAsync(_smartphone);

			//Act
			var result = await _controller.GetAll();

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var positions = okObjectResult.Value as IEnumerable<SmartphoneResponse>;
			Assert.NotNull(positions);
			Assert.Equal(expectedCount, positions.Count());
		}

		[Fact]
		public async Task Smartphone_Update_SmartphoneBrand()
		{
			//setup
			var SmartphoneId = 13;
			var expectedSmartphoneBrand = "Lenovo";

			var position = _smartphone.FirstOrDefault(x => x.SmartphoneId == SmartphoneId);
			position.SmartphoneBrand = expectedSmartphoneBrand;


			_smartphoneRepository.Setup(x => x.Update(It.IsAny<Smartphone>())).Callback(() =>
			{
				position.SmartphoneBrand = expectedSmartphoneBrand;
			}).Returns(() => Task<Smartphone>.Factory.StartNew(() => new Smartphone()
			{
				SmartphoneId = position.SmartphoneId,
				SmartphoneBrand = position.SmartphoneBrand,
				SmartphoneModel = position.SmartphoneModel,
				DateOfManufacturing = position.DateOfManufacturing,
				Inch = position.Inch,
				BackCameraMP = position.BackCameraMP,
				FrontCameraMP = position.FrontCameraMP,
				Memory = position.Memory,
				BaterymAh = position.BaterymAh

			}));

			//Act
			var result = await _controller.Update(_mapper.Map<SmartphoneRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as SmartphoneResponse;
			Assert.NotNull(pos);
			Assert.Equal(expectedSmartphoneBrand, pos.SmartphoneBrand);
		}

		[Fact]
		public async Task Smartphone_Delete_Existing_SmartphoneId()
		{
			//setup
			var SmartphoneId = 15;

			var position = _smartphone.FirstOrDefault(x => x.SmartphoneId == SmartphoneId);


			_smartphoneRepository.Setup(x => x.GetById(SmartphoneId)).ReturnsAsync(_smartphone.FirstOrDefault(x => x.SmartphoneId == SmartphoneId));
			_smartphoneRepository.Setup(x => x.Delete(SmartphoneId)).Callback(() => _smartphone.Remove(position));

			//Act
			var result = await _controller.Delete(SmartphoneId);

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.Null(okObjectResult);

			Assert.Null(_smartphone.FirstOrDefault(x => x.SmartphoneId == SmartphoneId));
		}

		[Fact]
		public async Task Smartphone_Delete_NotExisting_SmartphoneId()
		{
			//setup
			var SmartphoneId = 3;

			var position = _smartphone.FirstOrDefault(x => x.SmartphoneId == SmartphoneId);


			_smartphoneRepository.Setup(x => x.Delete(SmartphoneId)).Callback(() => _smartphone.Remove(position));

			//Act
			var result = await _controller.Delete(SmartphoneId);

			//Assert
			var notFoundObjectResult = result as NotFoundObjectResult;
			Assert.Null(notFoundObjectResult);

			Assert.Null(_smartphone.FirstOrDefault(x => x.SmartphoneId == SmartphoneId));
		}

		[Fact]
		public async Task Smartphone_Create_SmartphoneBrand()
		{
			//setup
			var position = new Smartphone()
			{
				SmartphoneId = 14,
				SmartphoneBrand = "Prestigio",
				SmartphoneModel = "Muze D5",
				DateOfManufacturing = new DateTime(2020, 11, 13),
				Inch = "5",
				BackCameraMP = "8MP",
				FrontCameraMP = "4MP",
				Memory = "	16GB",
				BaterymAh = "2400 mAh"
			};

			_smartphoneRepository.Setup(x => x.Create(It.IsAny<Smartphone>())).Callback(() =>
			{
				_smartphone.Add(position);
			}).Returns(() => Task<Smartphone>.Factory.StartNew(() => new Smartphone()
			{
				SmartphoneId = 14,
				SmartphoneBrand = "Prestigio",
				SmartphoneModel = "Muze D5",
				DateOfManufacturing = new DateTime(2020, 11, 13),
				Inch = "5",
				BackCameraMP = "8MP",
				FrontCameraMP = "4MP",
				Memory = "	16GB",
				BaterymAh = "2400 mAh"


			}));

			//Act
			var result = await _controller.Create(_mapper.Map<SmartphoneRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as SmartphoneResponse;
			Assert.NotNull(pos);

			Assert.NotNull(_smartphone.FirstOrDefault(x => x.SmartphoneId == position.SmartphoneId));
		}
	}
}
