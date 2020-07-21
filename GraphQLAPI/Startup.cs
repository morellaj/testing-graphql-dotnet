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
        type Employee {
          employeeNumber: String!
          firstName: String!
          lastName: String!
          employeeEmail: String!
          employeeMetrics: EmployeeMetrics!
        }

        type EmployeeMetrics {
          employeeNumber: String!
          billableTargetHours: Int!
          billableCurrentHours: Int!
          trainingTargetHours: Int!
          trainingCurrentHours: Int!
          totalAnnualPTO: Int!
          overflowPTO: Int!
          usedPTO: Int!
          totalYearHours: Int!
          employee: Employee!
        }

        type Query {
          employee(firstName: String, lastName: String, employeeEmail: String, employeeNumber: String): Employee,

          allEmployees(
            firstName: String, 
            lastName: String, 
            employeeEmail: String, 
            employeeNumber: String,
            billableTargetHours: Int,
            billableCurrentHours: Int,
            trainingTargetHours: Int,
            trainingCurrentHours: Int,
            totalAnnualPTO: Int,
            overflowPTO: Int,
            usedPTO: Int,
            totalYearHours: Int
          ): [Employee],

          employeeMetrics(
            billableTargetHours: Int,
            billableCurrentHours: Int,
            trainingTargetHours: Int,
            trainingCurrentHours: Int,
            totalAnnualPTO: Int,
            overflowPTO: Int,
            usedPTO: Int,
            totalYearHours: Int,
            employeeNumber: String
          ): EmployeeMetrics,
          
          allEmployeeMetrics(
            billableTargetHours: Int,
            billableCurrentHours: Int,
            trainingTargetHours: Int,
            trainingCurrentHours: Int,
            totalAnnualPTO: Int,
            overflowPTO: Int,
            usedPTO: Int,
            totalYearHours: Int,
            employeeNumber: String
          ): [EmployeeMetrics],
        }
        ", _ =>
        {
          _.Types.Include<Query>();
          _.Types.Include<EmployeeType>();
          _.Types.Include<EmployeeMetricsType>();
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
