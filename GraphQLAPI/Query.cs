using GraphQL;
using System.Collections.Generic;
using System.Linq;
using GraphQLAPI.Data;

namespace GraphQLAPI
{
  public class Query
  {
    private bool ArgEqualsSource(string arg, string source)
    {
      return arg == null ? true : arg == source;
    }

    private bool ArgSmallerThanSource(int arg, int source)
    {
      return arg <= source;
    }

    [GraphQLMetadata("employee")]
    public Employee GetEmployee(string firstName, string lastName, string employeeEmail, string employeeNumber)
    {
      return EmployeeData.EmployeeList.FirstOrDefault(employee =>
      {
        return (
          ArgEqualsSource(firstName, employee.FirstName) &&
          ArgEqualsSource(lastName, employee.LastName) &&
          ArgEqualsSource(employeeEmail, employee.EmployeeEmail) &&
          ArgEqualsSource(employeeNumber, employee.EmployeeNumber)
          );
      });
    }

    [GraphQLMetadata("allEmployees")]
    public List<Employee> GetAllEmployees(
      string firstName,
      string lastName,
      string employeeEmail,
      string employeeNumber,
      int billableTargetHours,
      int billableCurrentHours,
      int trainingTargetHours,
      int trainingCurrentHours,
      int totalAnnualPTO,
      int overflowPTO,
      int usedPTO,
      int totalYearHours
      )
    {
      return EmployeeData.EmployeeList.Where(employee =>
      {
        EmployeeMetrics metrics = EmployeeData.EmployeeMetricsList.FirstOrDefault(emp =>
        {
          return emp.EmployeeNumber == employee.EmployeeNumber;
        });

        return (
          ArgEqualsSource(firstName, employee.FirstName) &&
          ArgEqualsSource(lastName, employee.LastName) &&
          ArgEqualsSource(employeeEmail, employee.EmployeeEmail) &&
          ArgEqualsSource(employeeNumber, employee.EmployeeNumber) &&
          ArgSmallerThanSource(billableTargetHours, metrics.BillableTargetHours) &&
          ArgSmallerThanSource(billableCurrentHours, metrics.BillableCurrentHours) &&
          ArgSmallerThanSource(trainingTargetHours, metrics.TrainingTargetHours) &&
          ArgSmallerThanSource(trainingCurrentHours, metrics.TrainingCurrentHours) &&
          ArgSmallerThanSource(totalAnnualPTO, metrics.TotalAnnualPTO) &&
          ArgSmallerThanSource(overflowPTO, metrics.OverflowPTO) &&
          ArgSmallerThanSource(usedPTO, metrics.UsedPTO) &&
          ArgSmallerThanSource(totalYearHours, metrics.TotalYearHours)
          );
      }).ToList();
    }

    [GraphQLMetadata("employeeMetrics")]
    public EmployeeMetrics GetEmployeeMetrics(
      int billableTargetHours,
      int billableCurrentHours,
      int trainingTargetHours,
      int trainingCurrentHours,
      int totalAnnualPTO,
      int overflowPTO,
      int usedPTO,
      int totalYearHours,
      string employeeNumber
      )
    {
      return EmployeeData.EmployeeMetricsList.FirstOrDefault(metrics =>
      {
        return (
          ArgSmallerThanSource(billableTargetHours, metrics.BillableTargetHours) &&
          ArgSmallerThanSource(billableCurrentHours, metrics.BillableCurrentHours) &&
          ArgSmallerThanSource(trainingTargetHours, metrics.TrainingTargetHours) &&
          ArgSmallerThanSource(trainingCurrentHours, metrics.TrainingCurrentHours) &&
          ArgSmallerThanSource(totalAnnualPTO, metrics.TotalAnnualPTO) &&
          ArgSmallerThanSource(overflowPTO, metrics.OverflowPTO) &&
          ArgSmallerThanSource(usedPTO, metrics.UsedPTO) &&
          ArgSmallerThanSource(totalYearHours, metrics.TotalYearHours) &&
          ArgEqualsSource(employeeNumber, metrics.EmployeeNumber)
        );
      });
    }

    [GraphQLMetadata("allEmployeeMetrics")]
    public List<EmployeeMetrics> GetAllEmployeeMetrics(
      int billableTargetHours,
      int billableCurrentHours,
      int trainingTargetHours,
      int trainingCurrentHours,
      int totalAnnualPTO,
      int overflowPTO,
      int usedPTO,
      int totalYearHours,
      string employeeNumber
      )
    {
      return EmployeeData.EmployeeMetricsList.Where(metrics =>
      {
        return (
          ArgSmallerThanSource(billableTargetHours, metrics.BillableTargetHours) &&
          ArgSmallerThanSource(billableCurrentHours, metrics.BillableCurrentHours) &&
          ArgSmallerThanSource(trainingTargetHours, metrics.TrainingTargetHours) &&
          ArgSmallerThanSource(trainingCurrentHours, metrics.TrainingCurrentHours) &&
          ArgSmallerThanSource(totalAnnualPTO, metrics.TotalAnnualPTO) &&
          ArgSmallerThanSource(overflowPTO, metrics.OverflowPTO) &&
          ArgSmallerThanSource(usedPTO, metrics.UsedPTO) &&
          ArgSmallerThanSource(totalYearHours, metrics.TotalYearHours) &&
          ArgEqualsSource(employeeNumber, metrics.EmployeeNumber)
        );
      }).ToList();
    }
  }

  [GraphQLMetadata("Employee", IsTypeOf = typeof(Employee))]
  public class EmployeeType
  {
    public string FirstName(Employee emp) => emp.FirstName;
    public string LastName(Employee emp) => emp.LastName;
    public string EmployeeNumber(Employee emp) => emp.EmployeeNumber;
    public string EmployeeEmail(Employee emp) => emp.EmployeeEmail;
    public EmployeeMetrics EmployeeMetrics(Employee source)
    {
      return EmployeeData.EmployeeMetricsList.FirstOrDefault(metrics =>
      {
        return metrics.EmployeeNumber == source.EmployeeNumber;
      });
    }
  }

  [GraphQLMetadata("EmployeeMetrics", IsTypeOf = typeof(EmployeeMetrics))]
  public class EmployeeMetricsType
  {
    public int BillableTargetHours(EmployeeMetrics metrics) => metrics.BillableTargetHours;
    public int BillableCurrentHours(EmployeeMetrics metrics) => metrics.BillableCurrentHours;
    public int TrainingTargetHours(EmployeeMetrics metrics) => metrics.TrainingTargetHours;
    public int TrainingCurrentHours(EmployeeMetrics metrics) => metrics.TrainingCurrentHours;
    public int TotalAnnualPTO(EmployeeMetrics metrics) => metrics.TotalAnnualPTO;
    public int OverflowPTO(EmployeeMetrics metrics) => metrics.OverflowPTO;
    public int UsedPTO(EmployeeMetrics metrics) => metrics.UsedPTO;
    public int TotalYearHours(EmployeeMetrics metrics) => metrics.TotalYearHours;
    public string EmployeeNumber(EmployeeMetrics metrics) => metrics.EmployeeNumber;
    public Employee Employee(EmployeeMetrics source)
    {
      return EmployeeData.EmployeeList.FirstOrDefault(employee =>
      {
        return employee.EmployeeNumber == source.EmployeeNumber;
      });
    }
  }
}