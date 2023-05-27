using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Web;

namespace CSVReader.Domain.Models;

public class DataFilter
{
    public string FilterBy { get; set; }

    public string FilterValue { get; set; }

    public string SortBy { get; set; }
    
    public OrderBy OrderBy { get; set; }
}