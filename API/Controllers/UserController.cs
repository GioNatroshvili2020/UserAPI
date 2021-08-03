using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.DAL.Entities;
using UserAPI.BLL.DTOs;
using UserAPI.BLL.Filter;
using UserAPI.BLL.IMapper;
using UserAPI.BLL.IRepository;

namespace API.Controllers
{
    [Route("api/[Controller]/[action]")]
    public class UserController:ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly IPersonMapper _mapper;
        public UserController(IPersonRepository repository,IPersonMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await  _repository.GetPersonAsync(id);

            if (person != null)
                return Ok(_mapper.GetPersonReadDto(person));
            else
                return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PersonFilter personFilter)
        {
            var people = await _repository.GetPersonListAsync(personFilter);

            return Ok(_mapper.GetPersonReadDtoList(people));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(AddPersonDto person)
        {
            try
            {
                var result = await _repository.AddPersonAsync(person);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(UpdatePersonDto person)
        {       
            try
            {
                var updatedPerson = await _repository.UpdatePersonAsync(person);

                return Ok(updatedPerson);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var res = await _repository.DeletePersonAsync(id);
            if (res.Result == false)
                return BadRequest(res.Message);
            else
                return Ok(res.Message);
        }
    }
}
