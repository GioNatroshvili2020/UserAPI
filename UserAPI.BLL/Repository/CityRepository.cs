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
    public class CityRepository : ICityRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        public CityRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CityModel> AddCityAsync(CreateCityDto model)
        {
            var cityToAdd = new City();
            cityToAdd.Name = model.Name;
            cityToAdd.DateCreated = DateTime.Now;
            _unitOfWork.Add(cityToAdd);
            await _unitOfWork.CommitAsync();

            return new CityModel() { 
                Name=cityToAdd.Name,
                ID=cityToAdd.ID
            };

        }

        public async Task<OperationResult> DeleteCityAsync(int ID)
        {

            var result = new OperationResult(true);
            var city = _unitOfWork.Query<City>().FirstOrDefault(n => n.ID == ID);

            if (city == null)
            {
                result.SetError("City Does Not Exist");
                return result;
            }
            city.DateDeleted = DateTime.Now;
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<City> GetCityAsync(int ID)
        {
            return await _unitOfWork.Query<City>().Where(n => n.DateDeleted == null).FirstOrDefaultAsync(n => n.ID == ID);
        }

        public async Task<List<CityModel>> GetCityListAsync()
        {
            var cities = await _unitOfWork.Query<City>().Where(x => x.DateDeleted == null).OrderBy(x => x.DateCreated).ToListAsync();

            var cityModels = new List<CityModel>();
            foreach(var c in cities)
            {
                cityModels.Add(new CityModel() { 
                        Name=c.Name,
                        ID=c.ID
                });
            }

            return cityModels;
        }


        public async Task<CityModel> UpdateCityAsync(CityModel model)
        {
            var existingCity = _unitOfWork.Query<City>().FirstOrDefault(x => x.ID == model.ID);
            if (existingCity != null)
            {
                existingCity.Name = model.Name;
                existingCity.DateChanged = DateTime.Now;
                await _unitOfWork.CommitAsync();

                return new CityModel()
                {
                    ID = existingCity.ID,
                    Name = existingCity.Name
                };

            }

            return null;

        }
    }
}
