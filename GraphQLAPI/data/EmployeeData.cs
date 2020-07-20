using System.Collections.Generic;

namespace GraphQLAPI.Data
{
  public class EmployeeData
  {
    public static List<Employee> EmployeeList = new List<Employee>() {
      new Employee {FirstName = "Daniel", LastName = "Moon", EmployeeNumber = 03223, EmployeeEmail = "daniel.moon@callibrity.com"},
      new Employee {FirstName = "Allen", LastName = "Hulley", EmployeeNumber = 1, EmployeeEmail = "ahulley@callibrity.com"},
      new Employee {FirstName = "Arielle", LastName = "Ferre", EmployeeNumber = 123123, EmployeeEmail = "arielle.ferre@callibrity.com"},
      new Employee {FirstName = "Collin", LastName = "Johnson", EmployeeNumber = 99999, EmployeeEmail = "collin.johnson@callibrity.com"},
      new Employee {FirstName = "Connor", LastName = "Mason", EmployeeNumber = 0919, EmployeeEmail = "cmason@callibrity.com"}
  };

    public static List<EmployeeMetrics> EmployeeMetricsList = new List<EmployeeMetrics>() {
      new EmployeeMetrics {EmployeeNumber = 03223, BillableTargetHours = 1, BillableCurrentHours = 2, TrainingTargetHours = 3, TrainingCurrentHours = 4, TotalAnnualPTO = 5, OverflowPTO = 6, UsedPTO = 7, TotalYearHours = 2020},
      new EmployeeMetrics {EmployeeNumber = 123123, BillableTargetHours = 100, BillableCurrentHours = 23, TrainingTargetHours = 10, TrainingCurrentHours = 2, TotalAnnualPTO = 15, OverflowPTO = 0, UsedPTO = 1, TotalYearHours = 2020},
      new EmployeeMetrics {EmployeeNumber = 99999, BillableTargetHours = 50, BillableCurrentHours = 7, TrainingTargetHours = 3, TrainingCurrentHours = 4, TotalAnnualPTO = 20, OverflowPTO = 8, UsedPTO = 8, TotalYearHours = 2020},
      new EmployeeMetrics {EmployeeNumber = 0919, BillableTargetHours = 200, BillableCurrentHours = 20, TrainingTargetHours = 40, TrainingCurrentHours = 10, TotalAnnualPTO = 80, OverflowPTO = 5, UsedPTO = 8, TotalYearHours = 2020},
      new EmployeeMetrics {EmployeeNumber = 1, BillableTargetHours = 1, BillableCurrentHours = 2, TrainingTargetHours = 777, TrainingCurrentHours = 4, TotalAnnualPTO = 5, OverflowPTO = 6, UsedPTO = 7, TotalYearHours = 2020}
    };
  }
}