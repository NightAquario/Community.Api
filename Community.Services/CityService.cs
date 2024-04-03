using Community.DTO;
using Community.IRepositories;
using Community.IServices;

namespace Community.Services;

public sealed class CityService : ICityService
{
    private readonly IUnitOfWork _unitOfWork;

    public CityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<City> GetCity(int cityId)
    {
        City city = _unitOfWork.CityRepository.GetById(cityId) ??
            throw new InvalidDataException($"City with Id : {cityId} could not be found");

        return Task.FromResult(city);
    }
    public Task<IQueryable<City>> GetCities()
    {
        throw new NotImplementedException();
    }
    public void AddCity(City city)
    {
        if (city == null) throw new ArgumentNullException(nameof(city));
        _unitOfWork.CityRepository.Insert(city);
        _unitOfWork.SaveChanges();
    }
    public void UpdateCity(City city)
    {
        if (city == null) throw new ArgumentNullException(nameof(city));
        _unitOfWork.CityRepository.Update(city);
        _unitOfWork.SaveChanges();

    }
    public void DeleteCity(int cityId)
    {
        City city = _unitOfWork.CityRepository.GetById(cityId);
        city.IsActive = false;
        _unitOfWork.CityRepository.Update(city);
        _unitOfWork.SaveChanges();
    }
}
