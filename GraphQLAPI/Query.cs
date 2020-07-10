using GraphQL;

namespace GraphQLAPI
{
  public class Query
  {
    [GraphQLMetadata("hero")]
    public Droid GetHero()
    {
      return new Droid { Id = "1", Name = "R2-D2" };
    }
  }
}