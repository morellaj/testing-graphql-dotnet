using System.Collections.Generic;

namespace GraphQLAPI.Data
{
  public class DroidData
  {
    public static List<Droid> DroidList = new List<Droid>() {
      new Droid {Id = "1", Name = "R2-D2", Height = 110, Coolness = 10, Missions = new List<int>() {1, 2}},
      new Droid {Id = "2", Name = "Megaman", Height = 132, Coolness = 1000, Missions = new List<int>() {2, 3}},
      new Droid {Id = "3", Name = "Bender", Height = 187, Coolness = 20, Missions = new List<int>() {2, 3}},
      new Droid {Id = "4", Name = "WALL-E", Height = 121, Coolness = 100, Missions = new List<int>() {1, 3}}
    };

    public static List<Mission> MissionList = new List<Mission>() {
      new Mission {Id = "1", Name = "Roll around and stuff", Difficulty = 0},
      new Mission {Id = "2", Name = "Avoid getting shot", Difficulty = 5},
      new Mission {Id = "3", Name = "Speak english", Difficulty = 8}
    };
  }
}