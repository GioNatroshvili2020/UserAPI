using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DAL.Entities;
using UserAPI.BLL.DTOs;
using UserAPI.BLL.Model;

namespace UserAPI.BLL.IMapper
{
    public interface IPersonMapper
    {
        PersonReadDto GetPersonReadDto(Person person);
        PersonReadDto GetPersonReadDto(PersonModel personModel);
        List<PersonReadDto> GetPersonReadDtoList(List<PersonModel> personList);
        public List<ConnectedPersonModel> GetConnectedPeopleModelList(List<ConnectedPerson> people);
    }
}
