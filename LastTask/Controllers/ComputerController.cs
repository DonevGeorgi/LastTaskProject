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
    [Route("Computer")]

    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private readonly IMapper _mapper;

        public ComputerController(IComputerService computerService, IMapper mapper)
        {
            _computerService = computerService;
            _mapper = mapper;
        }



        [HttpPost("Create")]

        public async Task<IActionResult> Create(ComputerRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }

            var position = _mapper.Map<Computer>(request);

            var result = await _computerService.Create(position);

            var response = _mapper.Map<ComputerResponse>(result);

            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] ComputerRequest request)
        {
            var result = await _computerService.Update(_mapper.Map<Computer>(request));

            if (result == null) return NotFound();

            var computer = _mapper.Map<ComputerResponse>(result);

            return Ok(computer);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _computerService.Delete(id);
            return Ok();
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _computerService.GetAll();

            if (result == null)
            {
                return NotFound("Collection is empty");
            }

            var computerresult = _mapper.Map<IEnumerable<ComputerResponse>>(result);

            return Ok(computerresult);
        }
    }
}
