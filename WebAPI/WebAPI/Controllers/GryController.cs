using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GryController : ControllerBase
    {
        private readonly IGetDataService _getService;
        private readonly IFormSubmitService _submitService;

        public GryController(IGetDataService getService, IFormSubmitService submitService)
        {
            _getService = getService;
            _submitService = submitService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_getService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var gra = _getService.GetById(id);
            if (gra == null) return NotFound();
            return Ok(gra);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GraDto dto)
        {
            var result = _submitService.Post(dto.Tytul, dto.Cena, dto.DataPremiery);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GraDto dto)
        {
            var result = _submitService.Put(id, dto.Tytul, dto.Cena, dto.DataPremiery);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}