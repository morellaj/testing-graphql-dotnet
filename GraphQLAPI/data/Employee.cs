using System.Collections.Generic;

namespace GraphQLAPI.Data
{
  public class Employee
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeEmail { get; set; }

    public string EmployeeNumber { get; set; }
    public EmployeeMetrics EmployeeMetrics { get; set; }
  }
}