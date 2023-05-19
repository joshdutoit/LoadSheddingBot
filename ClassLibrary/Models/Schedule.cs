using System.Runtime.InteropServices;
using CsvHelper.Configuration.Attributes;

namespace ClassLibrary.Models;

public class Schedule
{
    [Name("date_of_month")]
    public int DayOfMonth { get; set; }
    
    [Name("start_time")]
    public DateTime StartTime { get; set; }
    
    [Name("finsh_time")]
    public DateTime EndTime { get; set; }
    
    [Name("stage")]
    public int Stage { get; set; }
}