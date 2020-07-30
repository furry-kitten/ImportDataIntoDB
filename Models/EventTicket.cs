using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(event_ticket))]
    public class event_ticket : Product
    {
        public bool delivery { get; set; }
        public int local_delivery_cost { get; set; }
        public string name { get; set; }
        public string place { get; set; }
        public Hall plan { get; set; }
        public string hall_part { get; set; }
        public string date { get; set; }
        public int is_premiere { get; set; }
        public int is_kids { get; set; }
    }
}
