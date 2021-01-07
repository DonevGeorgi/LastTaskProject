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
	public class TelevisorTests
	{
		private IMapper _mapper;
		private Mock<ITelevisorRepository> _televisorRepository;
		private ITelevisorService _televisorService;
		private TelevisorController _controller;

		IList<Televisor> _televisor = new List<Televisor>()
			{
				{ new Televisor { TelevisorId = 8, TelevisorBrand ="LG ",TelevisorModel ="NANO796",DateOfManufacturing = new DateTime(2014, 10, 17),TelevisorCategory ="HDR LED",
				Inch = "55",Resolution ="3840 x 2160"} },
				{ new Televisor {  TelevisorId = 9, TelevisorBrand ="Bush",TelevisorModel ="Freeview",DateOfManufacturing = new DateTime(2016, 02, 20),TelevisorCategory ="LED",
				Inch = "22",Resolution =" 1920 x 1080 " } },
			};

		public TelevisorTests()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapping());
			});

			_mapper = mockMapper.CreateMapper();

			_televisorRepository = new Mock<ITelevisorRepository>();


			_televisorService = new TelevisorService(_televisorRepository.Object);

			//inject
			_controller = new TelevisorController(_televisorService, _mapper);
		}

		[Fact]
		public async Task Televisor_GetAll_Count_Check()
		{
			//setup
			var expectedCount = 2;

			_televisorRepository.Setup(x => x.GetAll())
				.ReturnsAsync(_televisor);

			//Act
			var result = await _controller.GetAll();

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var positions = okObjectResult.Value as IEnumerable<TelevisorResponse>;
			Assert.NotNull(positions);
			Assert.Equal(expectedCount, positions.Count());
		}

		[Fact]
		public async Task Televisor_Update_TelevisorBrand()
		{
			//setup
			var TelevisorId = 8;
			var expectedTelevisorBrand = "Samsung";

			var position = _televisor.FirstOrDefault(x => x.TelevisorId == TelevisorId);
			position.TelevisorBrand = expectedTelevisorBrand;


			_televisorRepository.Setup(x => x.Update(It.IsAny<Televisor>())).Callback(() =>
			{
				position.TelevisorBrand = expectedTelevisorBrand;
			}).Returns(() => Task<Televisor>.Factory.StartNew(() => new Televisor()
			{
				TelevisorId = position.TelevisorId,
				TelevisorBrand = position.TelevisorBrand,
				TelevisorModel = position.TelevisorModel,
				DateOfManufacturing = position.DateOfManufacturing,
				TelevisorCategory = position.TelevisorCategory,
				Inch = position.Inch,
				Resolution = position.Resolution

			}));

			//Act
			var result = await _controller.Update(_mapper.Map<TelevisorRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as TelevisorResponse;
			Assert.NotNull(pos);
			Assert.Equal(expectedTelevisorBrand, pos.TelevisorBrand);
		}

		[Fact]
		public async Task Televisor_Delete_Existing_TelevisorId()
		{
			//setup
			var TelevisorId = 9;

			var position = _televisor.FirstOrDefault(x => x.TelevisorId == TelevisorId);


			_televisorRepository.Setup(x => x.GetById(TelevisorId)).ReturnsAsync(_televisor.FirstOrDefault(x => x.TelevisorId == TelevisorId));
			_televisorRepository.Setup(x => x.Delete(TelevisorId)).Callback(() => _televisor.Remove(position));

			//Act
			var result = await _controller.Delete(TelevisorId);

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.Null(okObjectResult);

			Assert.Null(_televisor.FirstOrDefault(x => x.TelevisorId == TelevisorId));
		}

		[Fact]
		public async Task Televisor_Delete_NotExisting_TelevisorId()
		{
			//setup
			var TelevisorId = 1;

			var position = _televisor.FirstOrDefault(x => x.TelevisorId == TelevisorId);


			_televisorRepository.Setup(x => x.Delete(TelevisorId)).Callback(() => _televisor.Remove(position));

			//Act
			var result = await _controller.Delete(TelevisorId);

			//Assert
			var notFoundObjectResult = result as NotFoundObjectResult;
			Assert.Null(notFoundObjectResult);

			Assert.Null(_televisor.FirstOrDefault(x => x.TelevisorId == TelevisorId));
		}

		[Fact]
		public async Task Televisor_Create_TelevisorBrand()
		{
			//setup
			var position = new Televisor()
			{
				TelevisorId = 7,
				TelevisorBrand = "LG",
				TelevisorModel = "UN71006LA",
				DateOfManufacturing = new DateTime(2016, 12, 27),
				TelevisorCategory = "LED",
				Inch = "60",
				Resolution = "3840 x 2160 "
			};

			_televisorRepository.Setup(x => x.Create(It.IsAny<Televisor>())).Callback(() =>
			{
				_televisor.Add(position);
			}).Returns(() => Task<Televisor>.Factory.StartNew(() => new Televisor()
			{
				TelevisorId = 7,
				TelevisorBrand = "LG",
				TelevisorModel = "UN71006LA",
				DateOfManufacturing = new DateTime(2016, 12, 27),
				TelevisorCategory = "LED",
				Inch = "60",
				Resolution = "3840 x 2160 "
			})); ;

			//Act
			var result = await _controller.Create(_mapper.Map<TelevisorRequest>(position));

			//Assert
			var okObjectResult = result as OkObjectResult;
			Assert.NotNull(okObjectResult);

			var pos = okObjectResult.Value as TelevisorResponse;
			Assert.NotNull(pos);

			Assert.NotNull(_televisor.FirstOrDefault(x => x.TelevisorId == position.TelevisorId));
		}
	}
}
