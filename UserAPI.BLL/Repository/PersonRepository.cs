using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DAL.DataContext;
using UserApi.DAL.Entities;
using UserAPI.BLL.DTOs;
using UserAPI.BLL.Enum;
using UserAPI.BLL.Filter;
using UserAPI.BLL.Helpers;
using UserAPI.BLL.IRepository;
using UserAPI.BLL.Model;

namespace UserAPI.BLL.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PersonRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public  async Task<Person> GetPersonAsync(int ID)
        {
            return  await _unitOfWork.Query<Person>().Where(n=>n.DateDeleted==null).Include(n => n.City).FirstOrDefaultAsync(n => n.ID == ID);
        }


        public async Task<List<PersonModel>> GetPersonListAsync(PersonFilter personFiler)
        {
           

            List<Person> persons = new List<Person>();

            if (personFiler.FullSearch != null)
            {
                persons = await FullSearch(personFiler);
            }
            else if (personFiler.QuickSearch != null)
            {
                persons =await QuickSearch(personFiler);
            }
            else
            {
                 persons = await (from p in _unitOfWork.Query<Person>()
                                     where p.DateDeleted == null
                                     orderby p.DateCreated descending
                                     select p).Include(n => n.City).ToListAsync();
            }
           

            var personModelList = new List<PersonModel>();

            foreach(var p in persons)
            {
                var newPerson = new PersonModel();

                newPerson.ID = p.ID;
                newPerson.BirthDate = p.BirthDate;
                newPerson.CityId = p.CityId;
                newPerson.CityName = p.City.Name;
                newPerson.Firstname = p.Firstname;
                newPerson.Lastname = p.Lastname;
                newPerson.Gender = (GenderEnum)p.Gender;
                newPerson.PhoneNumber = p.PhoneNumber;
                newPerson.PhoneNumberType = (PhoneNumTypeEnum)p.PhoneNumberType;
                newPerson.ImageLink = p.ImageLink;
                newPerson.IdNumber = p.IdNumber;
                newPerson.ConnectedPeople = await GetConnectedPeople(newPerson.ID);

                personModelList.Add(newPerson);
            }
            return personModelList;
         
        }
        public async Task<Person> AddPersonAsync(AddPersonDto model)
        {
            var newPerson = new Person();
            newPerson.BirthDate = model.BirthDate;
            newPerson.CityId = model.CityId;
            newPerson.Firstname = model.Firstname;
            newPerson.Lastname = model.Lastname;
            newPerson.Gender = model.Gender;
            newPerson.PhoneNumber = model.PhoneNumber;
            newPerson.PhoneNumberType = model.PhoneNumberType;
            newPerson.ImageLink = model.ImageLink;
            newPerson.IdNumber = model.IdNumber;
            newPerson.DateCreated = DateTime.Now;
            if (model.ConnectedPeople != null && model.ConnectedPeople.Count>0)
            {
                foreach (var p in model.ConnectedPeople)
                {

                    var personToAdd = await GetPersonAsync(p);

                    if (personToAdd == null)
                        throw new Exception("Connected User Not Found");

                    newPerson.ConnectedPeople.Add(personToAdd);
                }
            }
           
            _unitOfWork.Add(newPerson);
            await _unitOfWork.CommitAsync();
            return newPerson;
          
        }



        public async Task<Person> UpdatePersonAsync(UpdatePersonDto model)
        {
            var existingPerson = _unitOfWork.Query<Person>().FirstOrDefault(n => n.ID == model.ID);
            if (existingPerson != null)
            {
                existingPerson.Firstname = model.Firstname;
                existingPerson.Lastname = model.Lastname;
                existingPerson.PhoneNumber = model.PhoneNumber;
                existingPerson.PhoneNumberType = model.PhoneNumberType;
                existingPerson.CityId = model.CityId;
                existingPerson.Gender = model.Gender;
                existingPerson.BirthDate = model.BirthDate;

                existingPerson.DateChanged = DateTime.Now;

                await _unitOfWork.CommitAsync();

            }
            return null;
        }

        public async Task<OperationResult> DeletePersonAsync(int ID)
        {
            var result = new OperationResult(true);
            var person = _unitOfWork.Query<Person>().FirstOrDefault(n => n.ID == ID);

            if (person==null)
            {
                result.SetError("Person Does Not Exist");
                return result;
            }
            person.DateDeleted = DateTime.Now;
            await _unitOfWork.CommitAsync();
            return result;
        }




        private async Task<List<PersonModel>> GetConnectedPeople(int ID)
        {
            var connectedPeople = await (from p in _unitOfWork.Query<Person>()
                                         join c in _unitOfWork.Query<City>() on p.CityId equals c.ID
                                         where p.DateDeleted == null && c.DateDeleted == null
                                         select new PersonModel()
                                         {
                                             ID=p.ID,
                                             BirthDate=p.BirthDate,
                                             CityId=c.ID,
                                             CityName=c.Name,
                                             Firstname=p.Firstname,
                                             Lastname=p.Lastname,
                                             Gender=(GenderEnum)p.Gender,
                                             PhoneNumber=p.PhoneNumber,
                                             PhoneNumberType=(PhoneNumTypeEnum)p.PhoneNumberType,
                                             ImageLink=p.ImageLink,
                                             IdNumber=p.IdNumber,                                             
                                         }).AsNoTracking().ToListAsync();
            return connectedPeople;
        }


        private async Task<List<Person>> QuickSearch(PersonFilter personFiler)
        {
            var people = await (from p in _unitOfWork.Query<Person>()
                             where p.DateDeleted == null
                             &&
                             (EF.Functions.Like(p.Firstname, personFiler.QuickSearch)
                             || EF.Functions.Like(p.Lastname, personFiler.QuickSearch)
                             || EF.Functions.Like(p.IdNumber, personFiler.QuickSearch)
                             )
                             orderby p.DateCreated descending
                             select p).Include(n => n.City).ToListAsync();
            return people;
        }

        private async Task<List<Person>> FullSearch(PersonFilter personFilter)
        {
            var stringProperties = typeof(Person).GetProperties().Where(prop =>
            prop.PropertyType == personFilter.FullSearch.GetType());
           
            var people = await _unitOfWork.Query<Person>().Where(p =>
               stringProperties.Any(prop =>
               EF.Functions.Like(prop.GetValue(p, null).ToString(), personFilter.QuickSearch))).ToListAsync();

            return people;
        }
    }
}
