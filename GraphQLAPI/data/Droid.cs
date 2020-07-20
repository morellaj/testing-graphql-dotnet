using System.Collections.Generic;

namespace GraphQLAPI.Data
{
  public class Droid
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Coolness { get; set; }
    public List<int> Missions { get; set; }
  }
}