using GraphQL;
using System.Collections.Generic;
using System.Linq;
using GraphQLAPI.Data;

namespace GraphQLAPI
{
  public class Query
  {

    [GraphQLMetadata("droid")]
    public Droid GetDroid(string id, string name, int height, int coolness)
    {
      return DroidData.DroidList.FirstOrDefault(droid =>
      {
        bool idCheck = id != null ? droid.Id == id : true;
        bool nameCheck = name != null ? droid.Name == name : true;
        return idCheck && nameCheck;
      });
    }

    [GraphQLMetadata("allDroids")]
    public List<Droid> GetAllDroids(int height, int coolness)
    {
      return DroidData.DroidList.Where(droid =>
      {
        bool heightCheck = droid.Height >= height;
        bool coolnessCheck = droid.Coolness >= coolness;
        return heightCheck && coolnessCheck;
      }).ToList();
    }
  }
}