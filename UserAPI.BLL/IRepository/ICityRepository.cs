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
    public interface ICityRepository
    {
        Task<City> GetCityAsync(int ID);
        Task<List<CityModel>> GetCityListAsync();
        Task<CityModel> AddCityAsync(CreateCityDto model);
        Task<CityModel> UpdateCityAsync(CityModel model);
        Task<OperationResult> DeleteCityAsync(int ID);
    }
}
