using ImportTODBFromYML.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(Book))]
    public class Book : Product, IBook
    {
        public bool delivery { get; set; }
        public string series { get; set; }
        public string binding { get; set; }
        public int local_delivery_cost { get; set; }
        public int volume { get; set; }
        public int part { get; set; }
        public int page_extent { get; set; }

        public bool downloadable { get; set; }
        public string author { get; set; }
        public string name { get; set; }
        public string publisher { get; set; }
        public string ISBN { get; set; }
        public string language { get; set; }
        public int year { get; set; }
    }
}
