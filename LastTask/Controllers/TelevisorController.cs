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
    [Route("Televisor")]

    public class TelevisorController : ControllerBase
    {
        private readonly ITelevisorService _televisorService;
        private readonly IMapper _mapper;

        public TelevisorController(ITelevisorService televisorService, IMapper mapper)
        {
            _televisorService = televisorService;
            _mapper = mapper;
        }



        [HttpPost("Create")]

        public async Task<IActionResult> Create(TelevisorRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }

            var position = _mapper.Map<Televisor>(request);

            var result = await _televisorService.Create(position);

            var response = _mapper.Map<TelevisorResponse>(result);

            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] TelevisorRequest request)
        {
            var result = await _televisorService.Update(_mapper.Map<Televisor>(request));

            if (result == null) return NotFound();

            var televisor = _mapper.Map<TelevisorResponse>(result);

            return Ok(televisor);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _televisorService.Delete(id);
            return Ok();
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _televisorService.GetAll();

            if (result == null)
            {
                return NotFound("Collection is empty");
            }

            var televisorresult = _mapper.Map<IEnumerable<TelevisorResponse>>(result);

            return Ok(televisorresult);
        }
    }
}
