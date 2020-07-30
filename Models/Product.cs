using ImportTODBFromYML.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportTODBFromYML.Models
{
    [XmlInclude(typeof(VendorModel))]
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(AudioBook))]
    [XmlInclude(typeof(Tour))]
    [XmlInclude(typeof(ArtistTitle))]
    [XmlInclude(typeof(event_ticket))]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public abstract class Product
    {
        public double price { get; set; }
        public string url { get; set; }
        public string picture { get; set; }
        public string desctription { get; set; }
        public string currencyId { get; set; }
        public int categoryId { get; set; }
    }
}
