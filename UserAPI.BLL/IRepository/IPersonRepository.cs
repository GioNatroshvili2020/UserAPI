using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DAL.Entities;
using UserAPI.BLL.DTOs;
using UserAPI.BLL.Model;

namespace UserAPI.BLL.IRepository
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(int ID);
        Task<List<PersonModel>> GetAllPersons();
        Task<Person> AddPerson(AddPersonDto model);
        Task<Person> UpdatePerson(UpdatePersonDto model);
        Task<OperationResult> DeletePerson(int ID);
    }
}
