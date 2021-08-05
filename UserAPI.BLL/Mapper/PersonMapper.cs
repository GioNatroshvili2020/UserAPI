using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DAL.Entities;
using UserAPI.BLL.DTOs;
using UserAPI.BLL.Enum;
using UserAPI.BLL.IMapper;
using UserAPI.BLL.Model;

namespace UserAPI.BLL.Mapper
{
    public class PersonMapper : IPersonMapper
    {
        
      

        public PersonReadDto GetPersonReadDto(Person person)
        {
            var personDto = new PersonReadDto();
            personDto.ID = person.ID;
            personDto.Firstname = person.Firstname;
            personDto.Lastname = person.Lastname;
            personDto.PhoneNumber = person.PhoneNumber;
            personDto.PhoneNumberType = ((PhoneNumTypeEnum)person.PhoneNumberType).ToString();    
            personDto.Gender = ((GenderEnum)person.Gender).ToString();
            personDto.CityId = person.CityId != null ? (int)person.CityId : 0;           
            personDto.BirthDate = person.BirthDate;
            personDto.IdNumber = person.IdNumber;
            personDto.ImageLink = person.ImageLink;
            if (person.ConnectedPeople != null && person.ConnectedPeople.Count > 0)
                personDto.ConnectedPeople = GetReadConnectedPersonDtos(person.ConnectedPeople);
            
            return personDto;


        }

        private List<ReadConnectedPersonDto> GetReadConnectedPersonDtos(List<ConnectedPerson> connectedPeople)
        {
            var connectedPeopleDtos = new List<ReadConnectedPersonDto>();
            foreach(var p in connectedPeople)
            {
                connectedPeopleDtos.Add(new ReadConnectedPersonDto()
                {
                    PersonId = p.ConnectedPersonId,                    
                    ConnectionType = ((ConnectionTypeEnum)p.ConnectionType).ToString()

                });
            }
            return connectedPeopleDtos;

        }

        private List<ReadConnectedPersonDto> GetReadConnectedPersonDtos(List<ConnectedPersonModel> connectedPeople)
        {
            var connectedPeopleDtos = new List<ReadConnectedPersonDto>();
            foreach (var p in connectedPeople)
            {
                connectedPeopleDtos.Add(new ReadConnectedPersonDto()
                {
                    PersonId = p.PersonId,          
                    ConnectionType = (p.ConnectionType).ToString()

                });
            }
            return connectedPeopleDtos;

        }



        public PersonReadDto GetPersonReadDto(PersonModel person)
        {
            var personDto = new PersonReadDto();
            personDto.ID = person.ID;
            personDto.Firstname = person.Firstname;
            personDto.Lastname = person.Lastname;
            personDto.PhoneNumber = person.PhoneNumber;
            personDto.PhoneNumberType = person.PhoneNumberType.ToString();
            personDto.Gender = person.Gender.ToString();
            personDto.CityId = person.CityId ;
            personDto.BirthDate = person.BirthDate;
            personDto.IdNumber = person.IdNumber;
            personDto.ImageLink = person.ImageLink;
            if (person.ConnectedPeople != null && person.ConnectedPeople.Count > 0)
                personDto.ConnectedPeople = GetReadConnectedPersonDtos(person.ConnectedPeople);

            return personDto;
        }


        public List<PersonReadDto> GetPersonReadDtoList(List<PersonModel> personList)
        {
            var personDtoList = new List<PersonReadDto>();

            foreach(var p in personList)
            {
                personDtoList.Add(GetPersonReadDto(p));
            }

            return personDtoList;
        }


        public List<ConnectedPersonModel> GetConnectedPeopleModelList(List<ConnectedPerson> people)
        {
            var connectedPeople = new List<ConnectedPersonModel>();
            foreach (var p in people)
            {
                var newPerson = new ConnectedPersonModel();

                newPerson.PersonId = p.ConnectedPersonId;             
                connectedPeople.Add(newPerson);
            }

            return connectedPeople;
        }
       
    }
}
