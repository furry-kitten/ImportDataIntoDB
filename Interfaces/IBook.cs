using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportTODBFromYML.Interfaces
{
    public interface IBook
    {
        bool downloadable { get; set; }
        string author { get; set; }
        string name { get; set; }
        string publisher { get; set; }
        string ISBN { get; set; }
        string language { get; set; }
        int year { get; set; }
    }
}
