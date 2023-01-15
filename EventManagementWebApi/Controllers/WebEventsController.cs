using EventManagementWebApi.Interfaces;
using EventManagementWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebEventsController : ControllerBase
    {
        private readonly IWebEventsRepository _repository;
        public WebEventsController(IWebEventsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WebEvent>))]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        
        [HttpGet("{webEventId}", Name = nameof(GetById))]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebEvent))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int webEventId)
        {
            var exisitngWebEvent = _repository.GetById(webEventId);
            if (exisitngWebEvent == null) return NotFound();
            return Ok(exisitngWebEvent);
        } 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(WebEvent))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] WebEvent webEvent)
        {
            if (webEvent.Id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            _repository.Add(webEvent);
            return CreatedAtAction(nameof(GetById), new {id = webEvent.Id }, webEvent);
        }

        [HttpDelete]
        [Route("{webEventId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete( int webEventId)
        {
            try
            {
                _repository.DeleteById(webEventId);
            }
            catch(ArgumentException ex)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
