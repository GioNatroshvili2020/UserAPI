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
            personDto.Gender = ((GenderEnum)person.Gender).ToString();
            personDto.PhoneNumberType = ((PhoneNumTypeEnum)person.PhoneNumberType).ToString();
            personDto.CityId = person.CityId;
            personDto.ConnectedPeople = GetConnectedPeople(person.ConnectedPeople);
            
            return personDto;


        }

        public PersonReadDto GetPersonReadDto(PersonModel person)
        {
            var personDto = new PersonReadDto();
            personDto.ID = person.ID;
            personDto.Firstname = person.Firstname;
            personDto.Lastname = person.Lastname;
            personDto.PhoneNumber = person.PhoneNumber;
            personDto.Gender = person.Gender.ToString();
            personDto.PhoneNumberType = person.PhoneNumberType.ToString();
            personDto.CityId = person.CityId;
            personDto.ConnectedPeople = GetConnectedPeople(person.ConnectedPeople);

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


        private List<PersonReadDto> GetConnectedPeople(List<PersonModel> people)
        {
            var connectedPeople = new List<PersonReadDto>();
            foreach (var p in people)
            {
                var newPerson = new PersonReadDto();

                newPerson.ID = p.ID;
                newPerson.BirthDate = p.BirthDate;
                newPerson.CityId = p.CityId;
                newPerson.CityName = p.CityName;
                newPerson.Firstname = p.Firstname;
                newPerson.Lastname = p.Lastname;
                newPerson.Gender = p.Gender.ToString();
                newPerson.PhoneNumber = p.PhoneNumber;
                newPerson.PhoneNumberType = p.PhoneNumberType.ToString();
                newPerson.ImageLink = p.ImageLink;
                newPerson.IdNumber = p.IdNumber;

                connectedPeople.Add(newPerson);
            }

            return connectedPeople;
        }
        private List<PersonReadDto> GetConnectedPeople(List<Person> people)
        {
            var connectedPeople = new List<PersonReadDto>();
            foreach (var p in people)
            {
                var newPerson = new PersonReadDto();

                newPerson.ID = p.ID;
                newPerson.BirthDate = p.BirthDate;
                newPerson.CityId = p.CityId;
                newPerson.CityName = p.City.Name;
                newPerson.Firstname = p.Firstname;
                newPerson.Lastname = p.Lastname;
                newPerson.Gender = ((GenderEnum)p.Gender).ToString();
                newPerson.PhoneNumber = p.PhoneNumber;
                newPerson.PhoneNumberType =((PhoneNumTypeEnum) p.PhoneNumberType).ToString();
                newPerson.ImageLink = p.ImageLink;
                newPerson.IdNumber = p.IdNumber;

                connectedPeople.Add(newPerson);
            }

            return connectedPeople;

        }
    }
}
