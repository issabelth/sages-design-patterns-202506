using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern;

interface IReportService
{

}

class FileReportService : IReportService
{
}


class DbReportService : IReportService
{
}



class ReportServiceFactory
{
    public IReportService Create(string value)
    {
        if (value == "f")
            return new FileReportService();
        else if (value == "d")
            return new DbReportService();
        else
            throw new NotSupportedException();
    }
}
