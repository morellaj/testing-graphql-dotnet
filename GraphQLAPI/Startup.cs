using System;
using System.IO;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace GraphQLAPI
{
  public class Startup
  {

    public void Configure(IApplicationBuilder app)
    {
      var schema = Schema.For(@"
        type Droid {
            id: String!
            name: String!
            height: Int!
            coolness: Int!
        }

        type Query {
            droid(id: String, name: String): Droid,
            allDroids(height: Int, coolness: Int): [Droid]
        }
        ", _ =>
        {
          _.Types.Include<Query>();
        });

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.Run(async (context) =>
      {
        if (context.Request.Path.StartsWithSegments("/api/graphql") && string.Equals(context.Request.Method, "Post", StringComparison.OrdinalIgnoreCase))
        {
          string body;
          using (var streamReader = new StreamReader(context.Request.Body))
          {
            body = await streamReader.ReadToEndAsync();
          }

          var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);

          var result = await new DocumentExecuter().ExecuteAsync(doc =>
                {
                  doc.Schema = schema;
                  doc.Query = request.Query;
                });

          var json = new DocumentWriter(indent: true).Write(result);

          await context.Response.WriteAsync(json);
        }
      });
    }
  }
}
