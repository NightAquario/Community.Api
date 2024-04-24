using Community.DBC;
using Community.DTO;

namespace Community.Seeders;

public class PersonSeeder : BaseSeeder<Person>
{
    public PersonSeeder(CommunityDBContext context) : base(context)
    {

    }

    public override void Seed()
    {
        var TestData = new List<Person>
        {
            new Person {
                FirstName = "John",
                LastName = "Doe",
                Gender = 0,
                PersonalCode = "#0000",
                PersonalNumber = "00000000000",
                //City ????
                //Picture ????
            }
        };
    }
}
