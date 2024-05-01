using Community.DTO;
using Community.IRepositories;
using Community.IServices;

namespace Community.Services;

public sealed class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Person> GetPerson(int personId)
    {
        Person person = _unitOfWork.PersonRepository.GetById(personId) ??
            throw new InvalidDataException($"Person with Id : {personId} could not be found");
        
        return Task.FromResult(person);
    }

    public async Task<IEnumerable<Person>> GetPeople()
    {
        var people = await _unitOfWork.PersonRepository.SetAsync();
        return people;
    }

    public void AddPerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));
        _unitOfWork.PersonRepository.Insert(person);
        _unitOfWork.SaveChanges();
    }

    public void UpdatePerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));
        _unitOfWork.PersonRepository.Update(person);
        _unitOfWork.SaveChanges();
    }

    public void DeletePerson(int personId)
    {
        Person person = _unitOfWork.PersonRepository.GetById(personId);
        person.IsActive = false;
        _unitOfWork.PersonRepository.Update(person);
        _unitOfWork.SaveChanges();
    }
}
