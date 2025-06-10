using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP;

// Złe podejście: 
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }

    public void SaveToFile(string path)
    {
        File.WriteAllText(path, $"{Title}\n{Content}");
    }
}
