using AutoMapper;
using LastTask.BL.Interface;
using LastTask.Models.Products;
using LastTask.Models.Request;
using LastTask.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastTask.Controllers
{

    [ApiController]
    [Route("Laptop")]

    public class LaptopController : ControllerBase
    {
        private readonly ILaptopService _laptopService;
        private readonly IMapper _mapper;

        public LaptopController(ILaptopService laptopService, IMapper mapper)
        {
            _laptopService = laptopService;
            _mapper = mapper;
        }



        [HttpPost("Create")]

        public async Task<IActionResult> Create(LaptopRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }

            var position = _mapper.Map<Laptop>(request);

            var result = await _laptopService.Create(position);

            var response = _mapper.Map<LaptopResponse>(result);

            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] LaptopRequest request)
        {
            var result = await _laptopService.Update(_mapper.Map<Laptop>(request));

            if (result == null) return NotFound();

            var laptop = _mapper.Map<LaptopResponse>(result);

            return Ok(laptop);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _laptopService.Delete(id);
            return Ok();
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _laptopService.GetAll();

            if (result == null)
            {
                return NotFound("Collection is empty");
            }

            var laptopresult = _mapper.Map<IEnumerable<LaptopResponse>>(result);

            return Ok(laptopresult);
        }
    }
}
