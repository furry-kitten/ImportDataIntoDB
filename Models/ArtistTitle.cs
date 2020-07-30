using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(ArtistTitle))]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class ArtistTitle : Product// : artist
    {
        public string artist { get; set; }
        public string title { get; set; }
        public string media { get; set; }
        public int year { get; set; }
        public string starring { get; set; }
        public string director { get; set; }
        public string originalName { get; set; }
        public string country { get; set; }
    }
}
