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
using UserAPI.BLL.Model;

namespace API.Controllers
{
    [Route("api/[Controller]/[action]")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _repository;

        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var city = await _repository.GetCityAsync(id);

            if (city != null)
                return Ok(city);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _repository.GetCityListAsync();

            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityDto city)
        {
            if (city == null)
                return BadRequest("Person Object is null");

            if (!ModelState.IsValid)
            {
                var Errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new { x.Key, x.Value.Errors }).ToList();
                return BadRequest(Errors[0].Errors[0].ErrorMessage);
            }
            try
            {
                var result = await _repository.AddCityAsync(city);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(CityModel city)
        {

            if (city == null)
                return BadRequest("Person Object is null");
            if (!ModelState.IsValid)
            {
                var Errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new { x.Key, x.Value.Errors }).ToList();
                return BadRequest(Errors[0].Errors[0].ErrorMessage);
            }
            try
            {
                var updatedPerson = await _repository.UpdateCityAsync(city);

                return Ok(updatedPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var res = await _repository.DeleteCityAsync(id);
            if (res.Result == false)
                return BadRequest(res.Message);
            else
                return Ok(res.Message);
        }

    }
}
