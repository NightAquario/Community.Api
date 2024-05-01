using Community.DTO;
using Community.IServices;
using Community.Models;
using Microsoft.AspNetCore.Mvc;

namespace Community.Api.Controllers;

[Controller]
[Route("[controller]")]
public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<Person> GetPerson(int id) =>
        await _personService.GetPerson(id);

    [HttpGet]
    public async Task<IEnumerable<Person>> GetPeople() =>
        await _personService.GetPeople();

    [HttpPost]
    public void AddPerson(PersonModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException("The provided data was not sufficient");
        }

        Person newPerson = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = (Gender)model.Gender,
            PersonalCode = model.PersonalCode,
            PersonalNumber = model.PersonalNumber,
            BirthDate = model.BirthDate
        };
        _personService.AddPerson(newPerson);
    }

    [HttpPost]
    public void UpdatePerson(PersonModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException("The provided data was not sufficient");
        }

        Person updatedPerson = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = (Gender)model.Gender,
            PersonalCode = model.PersonalCode,
            PersonalNumber = model.PersonalNumber,
            BirthDate = model.BirthDate
        };
        _personService.UpdatePerson(updatedPerson);
    }

    [HttpDelete]
    public void DeletePerson(int id) =>
        _personService.DeletePerson(id);
}
