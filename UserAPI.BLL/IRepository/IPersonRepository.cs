using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.DAL.Entities;
using UserAPI.BLL.DTOs;
using UserAPI.BLL.Filter;
using UserAPI.BLL.Model;

namespace UserAPI.BLL.IRepository
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonAsync(int ID);
        Task<List<PersonModel>> GetPersonListAsync(PersonFilter filter);
        Task<Person> AddPersonAsync(AddPersonDto model);
        Task<Person> UpdatePersonAsync(UpdatePersonDto model);
        Task<OperationResult> DeletePersonAsync(int ID);
    }
}
