﻿using Community.DTO;

namespace Community.IServices;

public interface IPersonService
{
    Task<Person> GetPerson(int personId);
    Task<IQueryable<Person>> GetPersons();
    void AddPerson(Person person);
    void UpdatePerson(Person person);
    void DeletePerson(int personId);
}
