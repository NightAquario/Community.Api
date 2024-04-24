using Community.DBC;
using Community.DTO;

namespace Community.Seeders;

public class CitySeeder : BaseSeeder<City>
{
    public CitySeeder(CommunityDBContext context) : base(context)
    {

    }

    public override void Seed()
    {
        var testData = new List<City>
        {
            new City {
                Name = "Tbilisi",
            },

            new City {
                Name = "Batumi",
            },

            new City {
                Name = "Kutaisi",
            }
        };

        _context.Cities.AddRange(testData);
        _context.SaveChanges();
    }
}
