using AutoMapper;
using HabitifyBackend.Dto;
using HabitifyBackend.Interfaces;
using HabitifyBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HabitifyBackend.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Habit>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetHabits() 
        {
            var habits = await _habitRepository.GetHabits();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(_mapper.Map<List<HabitDto>>(habits));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
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
    }
}
