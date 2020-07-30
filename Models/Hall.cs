using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(Hall))]
    public class Hall
    {
        [XmlAttributeAttribute]
        public string plan { get; set; }
        public string Name { get; set; }
    }
}
