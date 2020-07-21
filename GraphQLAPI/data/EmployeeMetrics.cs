using System.Collections.Generic;

namespace GraphQLAPI.Data
{
  public class EmployeeMetrics
  {
    public int BillableTargetHours { get; set; }
    public int BillableCurrentHours { get; set; }
    public int TrainingTargetHours { get; set; }
    public int TrainingCurrentHours { get; set; }
    public int TotalAnnualPTO { get; set; }
    public int OverflowPTO { get; set; }
    public int UsedPTO { get; set; }
    public int TotalYearHours { get; set; }

    public string EmployeeNumber { get; set; }
    public Employee Employee { get; set; }
  }
}