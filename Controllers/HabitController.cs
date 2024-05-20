using AutoMapper;
using HabitifyBackend.Dto;
using HabitifyBackend.Interfaces;
using HabitifyBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HabitifyBackend.Controllers
{
    [Route("")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitRepository _habitRepository;
        private readonly IMapper _mapper;

        public HabitController(IHabitRepository habitRepository, IMapper mapper)
        {
            _habitRepository = habitRepository;
            _mapper = mapper;

        }

        [Authorize]
        [HttpGet("getAllHabits")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Habit>))] // Ok
        [ProducesResponseType(400)] // BadRequest
        [ProducesResponseType(401)] // Authorization
        public async Task<IActionResult> GetHabits() 
        {
            var habits = await _habitRepository.GetHabits();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(_mapper.Map<List<HabitDto>>(habits));
        }

        [Authorize]
        [HttpGet("getHabit/{id}")]
        [ProducesResponseType(200, Type = typeof(Habit))] // Ok
        [ProducesResponseType(400)] // BadRequest
        [ProducesResponseType(401)] // Authorization
        public IActionResult GetHabit(int id)
        {
            var habit = _habitRepository.GetHabit(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(habit == null) return NotFound();

            return Ok(_mapper.Map<HabitDto>(habit));
        }

        [Authorize]
        [HttpPost("createNewHabit")]
        [ProducesResponseType(201)] // Created
        [ProducesResponseType(400)] // BadRequest
        [ProducesResponseType(401)] // Authorization
        public async Task<IActionResult> CreateHabitAsync([FromBody] HabitDto habitDto)
        {
            if (habitDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var habit = new Habit
            {
                Name = habitDto.Name,
                Description = habitDto.Description,
                Frequency = habitDto.Frequency
            };

            var result = await _habitRepository.CreateHabit(habit);

            if(!result) return StatusCode(500, "An error occured while creating the Habit");

            return Ok("Habit Created :)");
        }

        [Authorize]
        [HttpPost("deleteHabit/{id}")]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(400)] // BadRequest
        [ProducesResponseType(401)] // Authorization
        public IActionResult DeleteHabit(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(!_habitRepository.DeleteHabit(id))
            {
                return StatusCode(500, "An error occured while deleting the Habit");
            }

            return Ok($"Habit {id} deleted");
        }

        [Authorize]
        [HttpPut("updateHabit/{id}")]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(400)] // BadRequest
        [ProducesResponseType(401)] // Authorization
        public IActionResult UpdateHabit(int id, [FromBody] HabitDto habitToUpdate)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);


            if (!_habitRepository.UpdateHabit(id, habitToUpdate))
            {
                return StatusCode(500, "Something went wrong when updating the habit");
            }

            return Ok($"Habit {id} updated");
        }
    }
}
