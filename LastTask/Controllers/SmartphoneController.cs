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
    [Route("Smartphone")]

    public class SmartphoneController : ControllerBase
    {
        private readonly ISmartphoneService _smartphoneService;
        private readonly IMapper _mapper;

        public SmartphoneController(ISmartphoneService smartphoneService, IMapper mapper)
        {
            _smartphoneService = smartphoneService;
            _mapper = mapper;
        }



        [HttpPost("Create")]

        public async Task<IActionResult> Create(SmartphoneRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }

            var position = _mapper.Map<Smartphone>(request);

            var result = await _smartphoneService.Create(position);

            var response = _mapper.Map<SmartphoneResponse>(result);

            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] SmartphoneRequest request)
        {
            var result = await _smartphoneService.Update(_mapper.Map<Smartphone>(request));

            if (result == null) return NotFound();

            var smartphone = _mapper.Map<SmartphoneResponse>(result);

            return Ok(smartphone);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _smartphoneService.Delete(id);
            return Ok();
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _smartphoneService.GetAll();

            if (result == null)
            {
                return NotFound("Collection is empty");
            }

            var smartphoneresult = _mapper.Map<IEnumerable<SmartphoneResponse>>(result);

            return Ok(smartphoneresult);
        }
    }
}
