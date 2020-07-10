using GraphQL;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLAPI
{
  public class Query
  {
    private List<Droid> _droids = new List<Droid>() {
        new Droid {Id = "1", Name = "R2-D2", Height = 110, Coolness = 10},
        new Droid {Id = "2", Name = "Megaman", Height = 132, Coolness = 1000},
        new Droid {Id = "3", Name = "Bender", Height = 187, Coolness = 20},
        new Droid {Id = "4", Name = "WALL-E", Height = 121, Coolness = 100}
      };

    [GraphQLMetadata("droid")]
    public Droid GetDroid(string id, string name, int height, int coolness)
    {
      return _droids.FirstOrDefault(droid =>
      {
        bool idCheck = id != null ? droid.Id == id : true;
        bool nameCheck = name != null ? droid.Name == name : true;
        return idCheck && nameCheck;
      });
    }

    [GraphQLMetadata("allDroids")]
    public List<Droid> GetAllDroids(int height, int coolness)
    {
      return _droids.Where(droid =>
      {
        bool heightCheck = droid.Height >= height;
        bool coolnessCheck = droid.Coolness >= coolness;
        return heightCheck && coolnessCheck;
      }).ToList();
    }
  }
}