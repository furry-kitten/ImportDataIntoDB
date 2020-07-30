using ImportTODBFromYML.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(AudioBook))]
    public class AudioBook : Product, IBook
    {
        public string performed_by { get; set; }
        public string performance_type { get; set; }
        public string storage { get; set; }
        public string format { get; set; }
        public string recording_length { get; set; }

        public bool downloadable { get; set; }
        public string author { get; set; }
        public string name { get; set; }
        public string publisher { get; set; }
        public string ISBN { get; set; }
        public string language { get; set; }
        public int year { get; set; }
    }
}
