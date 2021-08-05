using API.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public class UserController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly IPersonMapper _mapper;

        public UserController(IPersonRepository repository, IPersonMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _repository.GetPersonAsync(id);

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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePerson( [FromBody]AddPersonDto person)
        {
          
            var result = await _repository.AddPersonAsync(person);

            return Ok(_mapper.GetPersonReadDto(result));

        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePerson(UpdatePersonDto person)
        {
          
            var updatedPerson = await _repository.UpdatePersonAsync(person);

            return Ok(_mapper.GetPersonReadDto(updatedPerson));


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
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UpdateImage(ImageUploadModel model)
        {
            
                var file = model.Image;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string uniquePrefix = Guid.NewGuid().ToString().Substring(0, 4);
                    var fullPath = Path.Combine(pathToSave, uniquePrefix + "_" + fileName);
                    var dbPath = Path.Combine(folderName, uniquePrefix + "_" + fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    _repository.UpdatePersonImage(new ImageModel() { 
                        ImagePath=dbPath,
                        ImagePersonId= model.PersonId,
                    });
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest("File is Empty");
                }            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonImage(int id)
        {
            var person = await _repository.GetPersonAsync(id);
            if(person==null)
                return NotFound();

            var image = System.IO.File.OpenRead(person.ImageLink);


            return File(image, "image/jpeg");
        }


    }
}
